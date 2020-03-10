using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AppDockerLnx.Models;
using AppDockerLnx.Services;

namespace AppDockerLnx.Controllers
{
    public class PersonController : Controller
    {

        public PersonasServices personasServices = new PersonasServices();
        IConfiguration _iconfiguration;

        public PersonController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        [HttpPost]
        public IActionResult AddPreson(ReqPerson person)
        {
            MVConsulta mvConsulta = new MVConsulta();
            ReqPerson reqPerson = new ReqPerson { ICVEOPERACION = person.ICVEOPERACION, ICVEPERSONA = person.ICVEPERSONA, CNOMBRE = person.CNOMBRE, CAPPATERNO = person.CAPPATERNO, CAPMATERNO = person.CAPMATERNO };
            string urlPersonServ = _iconfiguration.GetSection("urlServices").GetSection("urlPersonServ").Value;
            mvConsulta.personas = personasServices.getPersonas(urlPersonServ, reqPerson);
            reqPerson = new ReqPerson { ICVEOPERACION = "0", ICVEPERSONA = "", CNOMBRE = "", CAPPATERNO = "", CAPMATERNO = "" };
            mvConsulta.personas = personasServices.getPersonas(urlPersonServ, reqPerson);
            //ViewData["Personas"] = mvConsulta;
            ViewBag.Message = mvConsulta;
            return View("~/Views/Home/Index.cshtml");

        }

        [HttpGet]
        public IActionResult removePerson(string ID)
        {
            MVConsulta mvConsulta = new MVConsulta();
            ReqPerson reqPerson = new ReqPerson { ICVEOPERACION = "3", ICVEPERSONA = ID, CNOMBRE = "", CAPPATERNO = "", CAPMATERNO = "" };
            string urlPersonServ = _iconfiguration.GetSection("urlServices").GetSection("urlPersonServ").Value;
            mvConsulta.personas = personasServices.getPersonas(urlPersonServ, reqPerson);
            reqPerson = new ReqPerson { ICVEOPERACION = "0", ICVEPERSONA = "", CNOMBRE = "", CAPPATERNO = "", CAPMATERNO = "" };
            mvConsulta.personas = personasServices.getPersonas(urlPersonServ, reqPerson);
            //ViewData["Personas"] = mvConsulta;
            ViewBag.Message = mvConsulta;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
