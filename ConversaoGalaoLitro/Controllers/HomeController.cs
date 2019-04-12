using ConversaoGalaoLitro.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConversaoGalaoLitro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var thamirys = "Gameiro";
            return View();
        }
        // Renato está na Unip

        // Renato Groffe: não sou um bot
        // Teste 123

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            var valorGalao = Convert.ToDouble(frm["txtGalao"]);

            Console.WriteLine("Palmeiras nao tem mundial");

            var conversao = new Conversao();
            var resultadoConversao = conversao.GalaoParaLitros(valorGalao);
            ViewBag.ResultadoConversao = resultadoConversao;

            return View();
        }
    }
}