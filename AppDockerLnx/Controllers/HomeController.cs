using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppDockerLnx.Models;
using AppDockerLnx.Services;
using Microsoft.Extensions.Configuration;

namespace AppDockerLnx.Controllers
{
    public class HomeController : Controller
    {
        public PersonasServices personasServices = new PersonasServices();
        IConfiguration _iconfiguration;

        public HomeController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            MVConsulta mvConsulta = new MVConsulta();
            ReqPerson personEmpty = new ReqPerson { ICVEOPERACION = "0", ICVEPERSONA = "", CNOMBRE = "", CAPPATERNO = "", CAPMATERNO = "" };
            string urlPersonServ = _iconfiguration.GetSection("urlServices").GetSection("urlPersonServ").Value;
            mvConsulta.personas = personasServices.getPersonas(urlPersonServ, personEmpty);
            //ViewData["Personas"] = mvConsulta;
            ViewBag.Message = mvConsulta;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
