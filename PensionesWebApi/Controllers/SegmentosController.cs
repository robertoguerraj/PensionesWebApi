using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PensionesWebApi.EntityFramework;
using PensionesWebApi.Models;

namespace PensionesWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentosController : ControllerBase
    {
        private readonly PensionesDBContext _context;

        public SegmentosController(PensionesDBContext context)
        {
            _context = context;
        }

        // GET: api/Segmentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Segmento>>> GetSegmentos()
        {
            return await _context.Segmentos.ToListAsync();
        }

        // GET: api/Segmentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Segmento>> GetSegmento(int id)
        {
            var segmento = await _context.Segmentos.FindAsync(id);

            if (segmento == null)
            {
                return NotFound();
            }

            return segmento;
        }

        // PUT: api/Segmentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSegmento(int id, Segmento segmento)
        {
            if (id != segmento.SegmentoId)
            {
                return BadRequest();
            }

            _context.Entry(segmento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegmentoExists(id))
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

        // POST: api/Segmentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Segmento>> PostSegmento(Segmento segmento)
        {
            _context.Segmentos.Add(segmento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSegmento", new { id = segmento.SegmentoId }, segmento);
        }

        // DELETE: api/Segmentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Segmento>> DeleteSegmento(int id)
        {
            var segmento = await _context.Segmentos.FindAsync(id);
            if (segmento == null)
            {
                return NotFound();
            }

            _context.Segmentos.Remove(segmento);
            await _context.SaveChangesAsync();

            return segmento;
        }

        private bool SegmentoExists(int id)
        {
            return _context.Segmentos.Any(e => e.SegmentoId == id);
        }
    }
}
