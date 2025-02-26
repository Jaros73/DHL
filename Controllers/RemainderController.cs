using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemainderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RemainderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remainder>>> GetRemainders()
        {
            return await _context.Remainders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Remainder>> GetRemainder(int id)
        {
            var remainder = await _context.Remainders.FindAsync(id);
            if (remainder == null)
            {
                return NotFound();
            }
            return remainder;
        }

        [HttpPost]
        public async Task<ActionResult<Remainder>> CreateRemainder(Remainder remainder)
        {
            _context.Remainders.Add(remainder);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRemainder), new { id = remainder.Id }, remainder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRemainder(int id, Remainder remainder)
        {
            if (id != remainder.Id)
            {
                return BadRequest();
            }

            _context.Entry(remainder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemainder(int id)
        {
            var remainder = await _context.Remainders.FindAsync(id);
            if (remainder == null)
            {
                return NotFound();
            }

            _context.Remainders.Remove(remainder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
