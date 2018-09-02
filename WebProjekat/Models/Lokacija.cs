using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Lokacija
    {
        public int Id { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public Adresa Adresa { get; set; }
    }
}