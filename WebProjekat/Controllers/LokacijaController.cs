using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.DataAccess;

namespace WebProjekat.Controllers
{
    [RoutePrefix("api")]
    public class LokacijaController : ApiController
    {
        [Route("Lokacija/{id}"), HttpGet]
        public Lokacija GetLokacija(int id)
        {
            return LokacijaPristupPodacima.GetLokacija(id);
        }
    }
}
