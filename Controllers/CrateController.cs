using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CrateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crate>>> GetCrates()
        {
            return await _context.Crates.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crate>> GetCrate(int id)
        {
            var crate = await _context.Crates.FindAsync(id);
            if (crate == null)
            {
                return NotFound();
            }
            return crate;
        }

        [HttpPost]
        public async Task<ActionResult<Crate>> CreateCrate(Crate crate)
        {
            _context.Crates.Add(crate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCrate), new { id = crate.Id }, crate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCrate(int id, Crate crate)
        {
            if (id != crate.Id)
            {
                return BadRequest();
            }

            _context.Entry(crate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrate(int id)
        {
            var crate = await _context.Crates.FindAsync(id);
            if (crate == null)
            {
                return NotFound();
            }

            _context.Crates.Remove(crate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
