using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WebApp.Models
{
    public class Produs
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data adaugarii")]
        public DateTime DataAdaugarii { get; set; }
        public int VanzatorID { get; set; }

        [Display(Name = "Nume Vanzator")]
        public Vanzator Vanzator { get; set; }
        public ICollection<CategoriiProduse> CategoriiProduse { get; set; }
    }
}
