using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DHL.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Location> Locations { get; set; } = new();

        public async Task OnGetAsync()
        {
            Locations = await _context.Locations.ToListAsync();
        }
    }
}
