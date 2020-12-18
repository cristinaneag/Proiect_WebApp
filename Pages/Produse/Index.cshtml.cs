using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_WebApp.Data;
using Proiect_WebApp.Models;

namespace Proiect_WebApp.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_WebApp.Data.Proiect_WebAppContext _context;

        public IndexModel(Proiect_WebApp.Data.Proiect_WebAppContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; }
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategorieID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProdusD = new ProdusData();

            ProdusD.Produse = await _context.Produs
                .Include(b => b.Vanzator)
                .Include(b => b.CategoriiProduse)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .OrderBy(b => b.Denumire)
                .ToListAsync();

            if (id != null) 
            {
                ProdusID = id.Value;
                Produs prod = ProdusD.Produse
                    .Where(i => i.ID == id.Value)
                    .Single();
                ProdusD.Categorii = prod.CategoriiProduse
                    .Select(s => s.Categorie);
            }
        }
    }
}
