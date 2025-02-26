using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DHL.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> Courses { get; set; } = new();

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses.ToListAsync();
        }
    }
}
