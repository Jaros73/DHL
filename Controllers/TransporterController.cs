using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransporterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transporter>>> GetTransporters()
        {
            return await _context.Transporters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transporter>> GetTransporter(int id)
        {
            var transporter = await _context.Transporters.FindAsync(id);
            if (transporter == null)
            {
                return NotFound();
            }
            return transporter;
        }

        [HttpPost]
        public async Task<ActionResult<Transporter>> CreateTransporter(Transporter transporter)
        {
            _context.Transporters.Add(transporter);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransporter), new { id = transporter.Id }, transporter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransporter(int id, Transporter transporter)
        {
            if (id != transporter.Id)
            {
                return BadRequest();
            }

            _context.Entry(transporter).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransporter(int id)
        {
            var transporter = await _context.Transporters.FindAsync(id);
            if (transporter == null)
            {
                return NotFound();
            }

            _context.Transporters.Remove(transporter);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
