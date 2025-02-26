using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DispatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispatch>>> GetDispatches()
        {
            return await _context.Dispatches.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dispatch>> GetDispatch(int id)
        {
            var dispatch = await _context.Dispatches.FindAsync(id);
            if (dispatch == null)
            {
                return NotFound();
            }

            return dispatch;
        }

        [HttpPost]
        public async Task<ActionResult<Dispatch>> CreateDispatch(Dispatch dispatch)
        {
            _context.Dispatches.Add(dispatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDispatch), new { id = dispatch.Id }, dispatch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDispatch(int id, Dispatch dispatch)
        {
            if (id != dispatch.Id)
            {
                return BadRequest();
            }

            _context.Entry(dispatch).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispatch(int id)
        {
            var dispatch = await _context.Dispatches.FindAsync(id);
            if (dispatch == null)
            {
                return NotFound();
            }

            _context.Dispatches.Remove(dispatch);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
