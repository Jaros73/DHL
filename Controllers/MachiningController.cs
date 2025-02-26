using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachiningController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MachiningController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Machining>>> GetMachinings()
        {
            return await _context.Machinings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Machining>> GetMachining(int id)
        {
            var machining = await _context.Machinings.FindAsync(id);
            if (machining == null)
            {
                return NotFound();
            }
            return machining;
        }

        [HttpPost]
        public async Task<ActionResult<Machining>> CreateMachining(Machining machining)
        {
            _context.Machinings.Add(machining);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMachining), new { id = machining.Id }, machining);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMachining(int id, Machining machining)
        {
            if (id != machining.Id)
            {
                return BadRequest();
            }

            _context.Entry(machining).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachining(int id)
        {
            var machining = await _context.Machinings.FindAsync(id);
            if (machining == null)
            {
                return NotFound();
            }

            _context.Machinings.Remove(machining);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
