using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebProjekat.DataAccess;

namespace WebProjekat.Controllers
{
    [RoutePrefix("api")]
    public class VoznjaController: ApiController
    {
        [Route("Voznja/{id}"), HttpGet]
        public Voznja GetVoznja(int id)
        {
            return VoznjaPristupPodacima.GetVoznja(id);
        }

        [Route("Voznja"), HttpPost]
        public Voznja KreirajVoznju([FromBody]Voznja voznja)
        {
            return VoznjaPristupPodacima.KreirajVoznju(voznja);
        }

        [Route("Voznja/AzurirajLokaciju/{id}"), HttpPost]
        public Voznja AzurirajStatusVoznje([FromBody]Voznja voznja, int id)
        {
            return VoznjaPristupPodacima.AzurirajLokacijuVoznje(voznja, id);
        }

        [Route("Dispecer/{idDisp}/Voznje"), HttpGet]
        public List<Voznja> IzlistajVoznjePoDispeceru(int idDisp)
        {
            return VoznjaPristupPodacima.IzlistajVoznjePoDispeceru(idDisp);
        }

        [Route("Vozac/{idVozac}/Voznje"), HttpGet]
        public List<Voznja> IzlistajVoznjePoVozacu(int idVozac)
        {
            return VoznjaPristupPodacima.IzlistajVoznjePoVozacu(idVozac);
        }
    }
}