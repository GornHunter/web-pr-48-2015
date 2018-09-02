using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProjekat.Models;
using static Projekat.Models.Enums;

namespace Projekat.Models
{
    public class Vozac : Korisnik
    {
        public List<Voznja> Voznje { get; set; }
        public Lokacija Lokacija { get; set; }
        public Automobil Automobil { get; set; }
    }
}