using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologicalGroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechnologicalGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnologicalGroup>>> GetGroups()
        {
            return await _context.TechnologicalGroups.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TechnologicalGroup>> GetGroup(int id)
        {
            var group = await _context.TechnologicalGroups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return group;
        }

        [HttpPost]
        public async Task<ActionResult<TechnologicalGroup>> CreateGroup(TechnologicalGroup group)
        {
            _context.TechnologicalGroups.Add(group);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, group);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, TechnologicalGroup group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await _context.TechnologicalGroups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            _context.TechnologicalGroups.Remove(group);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
