using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WebApp.Models
{
    public class CategoriiProdusePageModel:PageModel
    {
        public List<CategorieAleasa> CategorieAleasaDataList;
        public void PopulateAssignedCategoryData(Proiect_WebAppContext context, Produs produs) 
        { 
            var allCategories = context.Categorie;
            var bookCategories = new HashSet<int>(produs.CategoriiProduse.Select(c => c.ProdusID));
            CategorieAleasaDataList = new List<CategorieAleasa>();
            foreach (var cat in allCategories) 
            {
                CategorieAleasaDataList.Add(new CategorieAleasa
                { 
                    IDCategorie = cat.ID,
                    Nume = cat.Nume,
                    Aleasa = bookCategories.Contains(cat.ID) }); 
            } }
        public void UpdateProdusCategories(Proiect_WebAppContext context, string[] selectedCategories, Produs produsToUpdate)
        {
            if (selectedCategories == null) 
            {
                produsToUpdate.CategoriiProduse = new List<CategoriiProduse>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var produsCategories = new HashSet<int>(produsToUpdate.CategoriiProduse.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie) 
            { 
                if (selectedCategoriesHS.Contains(cat.ID.ToString())) 
                { 
                    if (!produsCategories.Contains(cat.ID)) 
                    {
                        produsToUpdate.CategoriiProduse.Add(new CategoriiProduse 
                        {
                            ProdusID = produsToUpdate.ID, IDCategorie = cat.ID
                        });
                    }
                } else 
                {
                    if (produsCategories.Contains(cat.ID)) 
                    {
                        CategoriiProduse courseToRemove = produsToUpdate.CategoriiProduse.SingleOrDefault(i => i.IDCategorie == cat.ID);
                        context.Remove(courseToRemove); 
                    } 
                }
            }
        }
    }
}
