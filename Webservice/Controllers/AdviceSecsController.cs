using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webservice.Models;

namespace Webservice.Controllers
{
    [Produces("application/json")]
    [Route("api/AdviceSecs")]
    public class AdviceSecsController : Controller
    {
        private readonly DatabaseContext _context;

        public AdviceSecsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AdviceSecs
        [HttpGet]
        public IEnumerable<AdviceSecs> GetAdvices()
        {
            return _context.Advices;
        }

        // GET: api/AdviceSecs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdviceSecs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adviceSecs = await _context.Advices.SingleOrDefaultAsync(m => m.AID == id);

            if (adviceSecs == null)
            {
                return NotFound();
            }

            return Ok(adviceSecs);
        }

        // PUT: api/AdviceSecs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdviceSecs([FromRoute] int id, [FromBody] AdviceSecs adviceSecs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adviceSecs.AID)
            {
                return BadRequest();
            }

            _context.Entry(adviceSecs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdviceSecsExists(id))
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

        // POST: api/AdviceSecs
        [HttpPost]
        public async Task<IActionResult> PostAdviceSecs([FromBody] AdviceSecs adviceSecs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Advices.Add(adviceSecs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdviceSecs", new { id = adviceSecs.AID }, adviceSecs);
        }

        // DELETE: api/AdviceSecs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdviceSecs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adviceSecs = await _context.Advices.SingleOrDefaultAsync(m => m.AID == id);
            if (adviceSecs == null)
            {
                return NotFound();
            }

            _context.Advices.Remove(adviceSecs);
            await _context.SaveChangesAsync();

            return Ok(adviceSecs);
        }

        private bool AdviceSecsExists(int id)
        {
            return _context.Advices.Any(e => e.AID == id);
        }
    }
}