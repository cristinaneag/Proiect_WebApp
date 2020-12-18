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
    public class IndexModel : PageModel
    {
        private readonly Proiect_WebApp.Data.Proiect_WebAppContext _context;

        public IndexModel(Proiect_WebApp.Data.Proiect_WebAppContext context)
        {
            _context = context;
        }

        public IList<Vanzator> Vanzator { get;set; }

        public async Task OnGetAsync()
        {
            Vanzator = await _context.Vanzator.ToListAsync();
        }
    }
}
