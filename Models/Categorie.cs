using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WebApp.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public ICollection<CategoriiProduse> CategoriiProduse { get; set; }
    }
}
