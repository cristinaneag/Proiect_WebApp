using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WebApp.Models
{
    public class CategoriiProduse
    {
        public int ID { get; set; }
        public int ProdusID { get; set; }
        public Produs Produs { get; set; }
        public int IDCategorie { get; set; }
        public Categorie Categorie { get; set; }
    }
}
