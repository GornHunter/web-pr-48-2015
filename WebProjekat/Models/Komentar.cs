using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public DateTime DatumObjave { get; set; }
        public int Ocena    { get; set; }
    }
}