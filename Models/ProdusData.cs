using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WebApp.Models
{
    public class ProdusData
    {
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategoriiProduse> CategoriiProduse { get; set; }
    }
}
