using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_WebApp.Data;
using Proiect_WebApp.Models;

namespace Proiect_WebApp.Pages.Vanzatori
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_WebApp.Data.Proiect_WebAppContext _context;

        public DeleteModel(Proiect_WebApp.Data.Proiect_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vanzator Vanzator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vanzator = await _context.Vanzator.FirstOrDefaultAsync(m => m.ID == id);

            if (Vanzator == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vanzator = await _context.Vanzator.FindAsync(id);

            if (Vanzator != null)
            {
                _context.Vanzator.Remove(Vanzator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
