using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Projekat.Models.Enums;

namespace WebProjekat.Controllers
{
    public class KorisnikController
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public decimal JMBG { get; set; } //promeniti u stirng
        public string KontaktTelefon { get; set; } // promeniti u string
        public string Email { get; set; }
    }
}