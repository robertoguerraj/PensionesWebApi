using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PensionesWebApi.DTOs;
using PensionesWebApi.EntityFramework;
using PensionesWebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace PensionesWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly PensionesDBContext _context;
        private readonly IMapper _mapper;

        public ComentariosController(PensionesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetComentarios()
        {
            var comentarios = await _context.Comentarios.Include(e => e.Expediente).ToListAsync();

            return _mapper.Map<List<ComentarioDTO>>(comentarios);
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioDTO>> GetComentario(int id)
        {
            var comentario = await _context.Comentarios.Include(e => e.Expediente).SingleOrDefaultAsync(x => x.ComentarioId == id);

            if (comentario == null)
            {
                return NotFound();
            }

            return _mapper.Map<ComentarioDTO>(comentario);
        }

        // PUT: api/Comentarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutComentario(int id, ComentarioDTO comentario)
        //{
        //    if (id != comentario.ComentarioId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(comentario).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ComentarioExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Comentarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ComentarioDTO>> PostComentario(ComentarioPostDTO comentarioDTO)
        {
            comentarioDTO.FechaCreacion = DateTime.Now;
            var comentario = _mapper.Map<Comentario>(comentarioDTO);

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComentario", new { id = comentario.ComentarioId }, comentario);
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComentarioDTO>> DeleteComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            var comentarioDTO = _mapper.Map<ComentarioDTO>(comentario);

            return comentarioDTO;
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.ComentarioId == id);
        }
    }
}
