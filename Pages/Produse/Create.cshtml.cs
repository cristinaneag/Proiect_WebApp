using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_WebApp.Data;
using Proiect_WebApp.Models;

namespace Proiect_WebApp.Pages.Produse
{
    public class CreateModel : CategoriiProdusePageModel
    {
        private readonly Proiect_WebApp.Data.Proiect_WebAppContext _context;

        public CreateModel(Proiect_WebApp.Data.Proiect_WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VanzatorID"] = new SelectList(_context.Set<Vanzator>(), "ID", "Nume");

            var produs = new Produs();
            produs.CategoriiProduse = new List<CategoriiProduse>();
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-//urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, produs);

            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */
            var newProdus = new Produs();
            if (selectedCategories != null)
            {
                newProdus.CategoriiProduse = new List<CategoriiProduse>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategoriiProduse
                    {
                        IDCategorie = int.Parse(cat)
                    };
                    newProdus.CategoriiProduse.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Produs>
                (newProdus, "Produs", i => i.Denumire, i => i.Descriere, i => i.Pret, i => i.DataAdaugarii, i => i.Vanzator)) 
            { 
                _context.Produs.Add(newProdus);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProdus);
            return Page();
        }
    }
}
