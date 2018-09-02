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
    public class VozacController : ApiController
    {
        [Route("Vozac/{id}"), HttpGet]
        public Vozac GetVozac(int id)
        {
            return VozacPristupPodacima.GetVozac(id);
        }
        
        [Route("Vozac/PromenaLokacije/{vozacId}"), HttpPut]
        public Lokacija AzurirajLokaciju([FromBody]Lokacija lokacija, int vozacId)
        {
            return VozacPristupPodacima.AzurirajLokaciju(lokacija, vozacId);
        }

    }
}
