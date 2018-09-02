using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Projekat.Models.Enums;

namespace Projekat.Models
{
    public class Automobil
    {
        public int Id { get; set; }
        public string Vozac { get; set; }
        public int GodisteAutomobila { get; set; }
        public string BrojRegistarskeOznake { get; set; }
        public int BrojTaksiVozila { get; set; }
        public TipAutomobila TipAutomobila { get; set; }
    }
}