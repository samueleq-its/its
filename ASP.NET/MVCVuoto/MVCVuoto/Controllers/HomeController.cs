using Microsoft.AspNetCore.Mvc;
using MVCVuoto.Models;
using System.Diagnostics;

namespace MVCVuoto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChiSiamo()
        {
            ViewBag.Message = "La nostra azienda è leader nel settore della vendita di prodotti online.";
            return View();
        }

        //GET: /Home/Contatto
        public IActionResult Contatto()
        {
            return View();
        }

        //POST: /Home/Contatto
        public IActionResult RecuperaContatto(ContattoViewModel contatto)
        {
            ViewData["Message"]= $"Grazie per averci contattato, {contatto.Nominativo}. Ti risponderemo al più presto all'indirizzo {contatto.Email}.";
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
