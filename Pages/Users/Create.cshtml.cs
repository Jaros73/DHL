using DHL.Data;
using DHL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DHL.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User2 { get; set; } = new User
        {
            FullName = string.Empty,
            Email = string.Empty,
            PasswordHash = string.Empty,
            Role = "User"
        };

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User2);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
