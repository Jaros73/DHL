using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionalReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegionalReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionalReport>>> GetReports()
        {
            return await _context.RegionalReports.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegionalReport>> GetReport(int id)
        {
            var report = await _context.RegionalReports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return report;
        }

        [HttpPost]
        public async Task<ActionResult<RegionalReport>> CreateReport(RegionalReport report)
        {
            _context.RegionalReports.Add(report);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReport), new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(int id, RegionalReport report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }

            _context.Entry(report).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var report = await _context.RegionalReports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.RegionalReports.Remove(report);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
