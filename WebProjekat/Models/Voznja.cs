using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProjekat.Models;
using static Projekat.Models.Enums;

namespace Projekat.Models
{
    public class Voznja
    {
        public int Id { get; set; }
        public DateTime DatumIVreme { get; set; }
        public Lokacija PolaznaLokacija { get; set; }
        public Lokacija OdredisnaLokacija { get; set; }
        public TipAutomobila ZeljeniTipAutomobila { get; set; }
        public Dispecer Dispecer { get; set; }
        public Vozac Vozac { get; set; }
        public decimal Iznos { get; set; }
        public StatusVoznje StatusVoznje { get; set; }
        public Komentar Komentar { get; set; }
    }
}