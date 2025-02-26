using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelayController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DelayController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delay>>> GetDelays()
        {
            return await _context.Delays.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Delay>> GetDelay(int id)
        {
            var delay = await _context.Delays.FindAsync(id);
            if (delay == null)
            {
                return NotFound();
            }
            return delay;
        }

        [HttpPost]
        public async Task<ActionResult<Delay>> CreateDelay(Delay delay)
        {
            _context.Delays.Add(delay);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDelay), new { id = delay.Id }, delay);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelay(int id, Delay delay)
        {
            if (id != delay.Id)
            {
                return BadRequest();
            }

            _context.Entry(delay).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelay(int id)
        {
            var delay = await _context.Delays.FindAsync(id);
            if (delay == null)
            {
                return NotFound();
            }

            _context.Delays.Remove(delay);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
