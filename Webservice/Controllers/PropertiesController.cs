using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webservice.Models;

namespace Webservice.Controllers
{
    [Produces("application/json")]
    [Route("api/Properties")]
    public class PropertiesController : Controller
    {
        private readonly DatabaseContext _context;

        public PropertiesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        public IEnumerable<Properties> GetProperty()
        {
            return _context.Property;
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperties([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var properties = await _context.Property.SingleOrDefaultAsync(m => m.PropId == id);

            if (properties == null)
            {
                return NotFound();
            }

            return Ok(properties);
        }

        // PUT: api/Properties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperties([FromRoute] int id, [FromBody] Properties properties)
        {
            if (!ModelState.IsValid)
            {



                return BadRequest(ModelState);
            }

            if (id != properties.PropId)
            {
                return BadRequest();
            }

            _context.Entry(properties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertiesExists(id))
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

        // POST: api/Properties
        [HttpPost]
        public async Task<IActionResult> PostProperties([FromBody] Properties properties)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Property.Add(properties);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperties", new { id = properties.PropId }, properties);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperties([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var properties = await _context.Property.SingleOrDefaultAsync(m => m.PropId == id);
            if (properties == null)
            {
                return NotFound();
            }

            _context.Property.Remove(properties);
            await _context.SaveChangesAsync();

            return Ok(properties);
        }

        private bool PropertiesExists(int id)
        {
            return _context.Property.Any(e => e.PropId == id);
        }
    }
}