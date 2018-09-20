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
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            var valorGalao = Convert.ToDouble(frm["txtGalao"]);
            var conversao = new Conversao();
            var resultadoConversao = conversao.GalaoParaLitros(valorGalao);
            ViewBag.ResultadoConversao = resultadoConversao;

            return View();
        }
    }
}