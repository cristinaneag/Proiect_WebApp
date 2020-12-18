using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WebApp.Models
{
    public class Vanzator
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }

        [Display(Name = "Nr. telefon")]
        public string Telef { get; set; }

        public ICollection<Produs> Produse { get; set; }


        public string FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
    }
}
