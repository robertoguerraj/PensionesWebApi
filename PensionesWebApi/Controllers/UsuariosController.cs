using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PensionesWebApi.DTOs;
using PensionesWebApi.EntityFramework;
using PensionesWebApi.Helpers;
using PensionesWebApi.Models;
using PensionesWebApi.Services;

namespace PensionesWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly PensionesDBContext _context;
        private readonly IMapper _mapper;
        private IUsuarioService _usuarioService;
        private IEmail _email;
        private readonly AppSettings _appSettings;

        public UsuariosController(PensionesDBContext context, IMapper mapper, IUsuarioService usuarioService, IOptions<AppSettings> appSettings, IEmail email)
        {
            _context = context;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _appSettings = appSettings.Value;
            _email = email;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.Include(r => r.Rol).Include(u => u.Ubicacion).ToListAsync();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.Include(r => r.Rol).Include(u => u.Ubicacion).SingleOrDefaultAsync(x => x.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioRegisterDTO usuarioDTO)
        {
            if (id != usuarioDTO.UbicacionId)
            {
                return BadRequest();
            }

            var oldUsuario = await _context.Usuarios.FindAsync(id);
            if (oldUsuario == null)
            {
                return NotFound();
            }

            var usuario = oldUsuario;

            usuario.Nombre = usuario.Nombre == usuarioDTO.Nombre ? usuario.Nombre : usuarioDTO.Nombre;
            usuario.Apellidos = usuario.Apellidos == usuarioDTO.Apellidos ? usuario.Apellidos : usuarioDTO.Apellidos;
            usuario.Email = usuario.Email == usuarioDTO.Email ? usuario.Email : usuarioDTO.Email;
            usuario.RolId = usuario.RolId == usuarioDTO.RolId ? usuario.RolId : usuarioDTO.RolId;
            usuario.UbicacionId = usuario.UbicacionId == usuarioDTO.UbicacionId ? usuario.UbicacionId : usuarioDTO.UbicacionId;

            _context.Entry(oldUsuario).State = EntityState.Detached;
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioRegisterDTO usuarioDTO)
        {
            try 
            { 
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                var temporalPassword = _usuarioService.CreateTemporalPassword();
                usuario = _usuarioService.GetUserProperties(usuario, temporalPassword);

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                _email.SendEmail(1, usuario, temporalPassword);

                return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Activo = false;
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return usuario;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<UsuarioTokenDTO>> Authenticate(UsuarioAuthenticateDTO usuarioDTO)
        {
            var usuario = await _context.Usuarios.Include(r => r.Rol).Include(u => u.Ubicacion).SingleOrDefaultAsync(x => x.UserName.ToLower() == usuarioDTO.UserName.ToLower());

            if (usuario == null)
                return BadRequest(new { message = "Usuario incorrecto." });

            var passwordValidated = _usuarioService.PasswordValidation(usuarioDTO.Password, usuario);

            if (!passwordValidated)
                return BadRequest(new { message = "Contraseña incorrecta." });

            var tokenString = _usuarioService.GetJsonToken(usuario.UsuarioId, _appSettings.Secret);

            var usuarioToken = _mapper.Map<UsuarioTokenDTO>(usuario);
            usuarioToken.Token = tokenString;

            return usuarioToken;
        }

        [AllowAnonymous]
        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword password)
        {
            try
            {
                var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == password.Identificacion || u.UserName == password.Identificacion);
                if (usuario == null)
                    return BadRequest(new { message = "Email o UserName incorrectos." });

                var temporalPassword = _usuarioService.CreateTemporalPassword();
                var passwordValues = _usuarioService.ForgotPassword(temporalPassword);

                usuario.PasswordHash = passwordValues.PasswordHash;
                usuario.PasswordSalt = passwordValues.PasswordSalt;
                usuario.TemporalPassword = passwordValues.TemporalPassword;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _email.SendEmail(3, usuario, temporalPassword);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return NoContent();
        }

        // PUT: api/Usuarios/password/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("password/{id}")]
        public async Task<IActionResult> UpdatePassword(int id, Password password)
        {
            if (id != password.UsuarioId)
            {
                return BadRequest();
            }

            var passwordValues = _usuarioService.UpdatePassword(password);
            var usuario = await _context.Usuarios.SingleAsync(u => u.UsuarioId == id);

            usuario.PasswordHash = passwordValues.PasswordHash;
            usuario.PasswordSalt = passwordValues.PasswordSalt;
            usuario.TemporalPassword = passwordValues.TemporalPassword;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                _email.SendEmail(2, usuario, password.NewPassword);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
