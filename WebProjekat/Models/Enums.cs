using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Enums
    {
        public enum Pol
        {
            Muski = 0,
            Zenski = 1
        };
        public enum TipAutomobila
        {
            Putnicko = 0,
            Kombi = 1
        };
        public enum StatusVoznje
        {
            Formirana = 0,
            Obradjena = 1,
            Prihvacena = 2,
            Neuspesna = 3,
            Uspesna = 4
        };
        
    }
}