using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DHL.Pages.Dispatches
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Dispatch> Dispatches { get; set; } = new();

        public async Task OnGetAsync()
        {
            Dispatches = await _context.Dispatches
                .Include(d => d.User) // Naèteme i uživatele
                .ToListAsync();
        }
    }
}
