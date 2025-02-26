using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationAssignmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocationAssignmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationAssignment>>> GetLocationAssignments()
        {
            return await _context.LocationAssignments
                .Include(la => la.Employee)
                .Include(la => la.Location)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationAssignment>> GetLocationAssignment(int id)
        {
            var locationAssignment = await _context.LocationAssignments
                .Include(la => la.Employee)
                .Include(la => la.Location)
                .FirstOrDefaultAsync(la => la.Id == id);

            if (locationAssignment == null)
            {
                return NotFound();
            }

            return locationAssignment;
        }

        [HttpPost]
        public async Task<ActionResult<LocationAssignment>> CreateLocationAssignment(LocationAssignment locationAssignment)
        {
            _context.LocationAssignments.Add(locationAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocationAssignment), new { id = locationAssignment.Id }, locationAssignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocationAssignment(int id, LocationAssignment locationAssignment)
        {
            if (id != locationAssignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationAssignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationAssignment(int id)
        {
            var locationAssignment = await _context.LocationAssignments.FindAsync(id);
            if (locationAssignment == null)
            {
                return NotFound();
            }

            _context.LocationAssignments.Remove(locationAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
