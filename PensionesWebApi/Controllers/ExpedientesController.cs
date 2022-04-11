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
    public class ExpedientesController : ControllerBase
    {
        private readonly PensionesDBContext _context;
        private readonly IMapper _mapper;
        public ExpedientesController(PensionesDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Expedientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpedienteDTO>>> GetExpedientes()
        {
            var expedientes = await _context.Expedientes.Include(f => f.Flujo).Include(di => di.DomicilioIFE).Include(dc => dc.DomicilioComprobante).ToListAsync();

            return _mapper.Map<List<ExpedienteDTO>>(expedientes);
        }

        // GET: api/Expedientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpedienteDTO>> GetExpediente(int id)
        {
            var expediente = await _context.Expedientes.Include(f => f.Flujo).Include(di => di.DomicilioIFE).Include(dc => dc.DomicilioComprobante).SingleOrDefaultAsync(x => x.ExpedienteId == id);

            if (expediente == null)
            {
                return NotFound();
            }

            return _mapper.Map<ExpedienteDTO>(expediente);
        }

        // PUT: api/Expedientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpediente(int id, ExpedientePostDTO expedienteDTO)
        {
            if (id != expedienteDTO.ExpedienteId)
            {
                return BadRequest();
            }

            var oldExpediente = await _context.Expedientes.SingleAsync(x => x.ExpedienteId == id);

            var domicilioIFE = _mapper.Map<DomicilioIFE>(expedienteDTO.DomicilioIFE);
            var domicilioComprobante = _mapper.Map<DomicilioComprobante>(expedienteDTO.DomicilioComprobante);
            var expediente = _mapper.Map<Expediente>(expedienteDTO);

            if(domicilioIFE.DomicilioIFEId != oldExpediente.DomicilioIFEId || domicilioComprobante.DomicilioComprobanteId != oldExpediente.DomicilioComprobanteId)
            {
                return BadRequest();
            }

            if (DomicilioIFEExists(oldExpediente.DomicilioIFEId))
            {
                _context.Entry(domicilioIFE).State = EntityState.Modified;
            }

            if (DomicilioComprobanteExists(oldExpediente.DomicilioComprobanteId))
            {
                _context.Entry(domicilioComprobante).State = EntityState.Modified;
            }

            expediente.FechaActualizacion = DateTime.Now;
            expediente.DomicilioIFEId = oldExpediente.DomicilioIFEId;
            expediente.DomicilioComprobanteId = oldExpediente.DomicilioComprobanteId;
            _context.Entry(oldExpediente).State = EntityState.Detached;
            _context.Entry(expediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpedienteExists(id))
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

        // POST: api/Expedientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExpedienteDTO>> PostExpediente(ExpedientePostDTO expediente)
        {
            if(NSSExists(expediente.NSS))
            {
                return BadRequest();
            }

            var mapExpediente = _mapper.Map<Expediente>(expediente);

            var domicilioIfe = expediente.DomicilioIFE != null ? _mapper.Map<DomicilioIFE>(expediente.DomicilioIFE) : new DomicilioIFE();
            var domicilioComprobante = expediente.DomicilioComprobante != null ? _mapper.Map<DomicilioComprobante>(expediente.DomicilioComprobante) : new DomicilioComprobante();

            _context.DomicilioIFEs.Add(domicilioIfe);
            _context.DomicilioComprobantes.Add(domicilioComprobante);
            await _context.SaveChangesAsync();

            mapExpediente.DomicilioIFEId = domicilioIfe.DomicilioIFEId;
            mapExpediente.DomicilioComprobanteId = domicilioComprobante.DomicilioComprobanteId;
            mapExpediente.FechaCreacion = DateTime.Now;

            _context.Expedientes.Add(mapExpediente);
            await _context.SaveChangesAsync();

            var nuevoExpediente = await _context.Expedientes.Include(f => f.Flujo).Include(di => di.DomicilioIFE).Include(dc => dc.DomicilioComprobante).SingleOrDefaultAsync(x => x.ExpedienteId == mapExpediente.ExpedienteId);

            return _mapper.Map<ExpedienteDTO>(nuevoExpediente);
        }

        // DELETE: api/Expedientes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Expediente>> DeleteExpediente(int id)
        //{
        //    var expediente = await _context.Expedientes.FindAsync(id);
        //    if (expediente == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Expedientes.Remove(expediente);
        //    await _context.SaveChangesAsync();

        //    return expediente;
        //}

        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.ExpedienteId == id);
        }

        private bool NSSExists(string nss)
        {
            return _context.Expedientes.Any(e => e.NSS == nss);
        }

        private bool DomicilioIFEExists(int? id)
        {
            return _context.DomicilioIFEs.Any(e => e.DomicilioIFEId == id);
        }

        private bool DomicilioComprobanteExists(int? id)
        {
            return _context.DomicilioComprobantes.Any(e => e.DomicilioComprobanteId == id);
        }
    }
}
