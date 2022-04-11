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
    public class FlujosController : ControllerBase
    {
        private readonly PensionesDBContext _context;

        public FlujosController(PensionesDBContext context)
        {
            _context = context;
        }

        // GET: api/Flujos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flujo>>> GetFlujos()
        {
            return await _context.Flujos.ToListAsync();
        }

        // GET: api/Flujos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flujo>> GetFlujo(int id)
        {
            var flujo = await _context.Flujos.FindAsync(id);

            if (flujo == null)
            {
                return NotFound();
            }

            return flujo;
        }

        // PUT: api/Flujos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlujo(int id, Flujo flujo)
        {
            if (id != flujo.FlujoId)
            {
                return BadRequest();
            }

            _context.Entry(flujo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlujoExists(id))
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

        // POST: api/Flujos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flujo>> PostFlujo(Flujo flujo)
        {
            _context.Flujos.Add(flujo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlujo", new { id = flujo.FlujoId }, flujo);
        }

        // DELETE: api/Flujos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flujo>> DeleteFlujo(int id)
        {
            var flujo = await _context.Flujos.FindAsync(id);
            if (flujo == null)
            {
                return NotFound();
            }

            _context.Flujos.Remove(flujo);
            await _context.SaveChangesAsync();

            return flujo;
        }

        private bool FlujoExists(int id)
        {
            return _context.Flujos.Any(e => e.FlujoId == id);
        }
    }
}
