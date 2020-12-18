using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_WebApp.Data;
using Proiect_WebApp.Models;

namespace Proiect_WebApp.Pages.Produse
{
    public class EditModel : CategoriiProdusePageModel
    {
        private readonly Proiect_WebApp.Data.Proiect_WebAppContext _context;

        public EditModel(Proiect_WebApp.Data.Proiect_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs
                .Include(b => b.Vanzator).
                Include(b => b.CategoriiProduse).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }

            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-//urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Produs);

            ViewData["VanzatorID"] = new SelectList(_context.Set<Vanzator>(), "ID", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(Produs.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */
            if (id == null) { return NotFound(); }
            var produsToUpdate = await _context.Produs
                .Include(b => b.Vanzator).
                Include(b => b.CategoriiProduse).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (produsToUpdate == null) { return NotFound(); }
            if (await TryUpdateModelAsync<Produs>(produsToUpdate, "Book", i => i.Denumire, i => i.Descriere, i => i.Pret, i => i.DataAdaugarii, i => i.Vanzator)) 
            { 
                UpdateProdusCategories(_context, selectedCategories, produsToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata
            UpdateProdusCategories(_context, selectedCategories, produsToUpdate);
            PopulateAssignedCategoryData(_context, produsToUpdate);
            return Page();
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.ID == id);
        }
    }
}
