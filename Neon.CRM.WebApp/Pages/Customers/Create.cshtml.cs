using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Neon.CRM.WebApp.Data;
using Neon.CRM.WebApp.Data.Models;

namespace Neon.CRM.WebApp.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Neon.CRM.WebApp.Data.ApplicationDbContext _context;

        public CreateModel(Neon.CRM.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var agents = _context.Users
                .Select(q => 
                    new { 
                        q.Id, 
                        q.FullName
                    }
                )
                .ToList();
            ViewData["AgentId"] = new SelectList(agents, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
