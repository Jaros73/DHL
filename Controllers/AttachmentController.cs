using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttachmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attachment>>> GetAttachments()
        {
            return await _context.Attachments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attachment>> GetAttachment(int id)
        {
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }
            return attachment;
        }

        [HttpPost]
        public async Task<ActionResult<Attachment>> CreateAttachment(Attachment attachment)
        {
            _context.Attachments.Add(attachment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAttachment), new { id = attachment.Id }, attachment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttachment(int id, Attachment attachment)
        {
            if (id != attachment.Id)
            {
                return BadRequest();
            }

            _context.Entry(attachment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }

            _context.Attachments.Remove(attachment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
