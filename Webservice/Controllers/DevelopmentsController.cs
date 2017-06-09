using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webservice.Models;

namespace Webservice.Controllers
{
    [Produces("application/json")]
    [Route("api/Developments")]
    public class DevelopmentsController : Controller
    {
        private readonly DatabaseContext _context;

        public DevelopmentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Developments
        [HttpGet]
        public IEnumerable<Developments> GetDevelopment()
        {
            return _context.Development;
        }

        // GET: api/Developments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevelopments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developments = await _context.Development.SingleOrDefaultAsync(m => m.Id == id);

            if (developments == null)
            {
                return NotFound();
            }

            return Ok(developments);
        }

        // PUT: api/Developments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevelopments([FromRoute] int id, [FromBody] Developments developments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != developments.Id)
            {
                return BadRequest();
            }

            _context.Entry(developments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevelopmentsExists(id))
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

        // POST: api/Developments
        [HttpPost]
        public async Task<IActionResult> PostDevelopments([FromBody] Developments developments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Development.Add(developments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevelopments", new { id = developments.Id }, developments);
        }

        // DELETE: api/Developments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevelopments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developments = await _context.Development.SingleOrDefaultAsync(m => m.Id == id);
            if (developments == null)
            {
                return NotFound();
            }

            _context.Development.Remove(developments);
            await _context.SaveChangesAsync();

            return Ok(developments);
        }

        private bool DevelopmentsExists(int id)
        {
            return _context.Development.Any(e => e.Id == id);
        }
    }
}