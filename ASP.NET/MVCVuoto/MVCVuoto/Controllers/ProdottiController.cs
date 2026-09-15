using Microsoft.AspNetCore.Mvc;
using MVCVuoto.Models;

namespace MVCVuoto.Controllers
{
    public class ProdottiController : Controller
    {

        static private List<Prodotto> lista = new List<Prodotto> {
                new Prodotto
                {
                    Denominazione = "Prodotto 1",
                    Codice = 1,
                    Descrizione = "Descrizione",
                    Giacenza = 100,
                    Prezzo = 10.0
                },
                new Prodotto
                {
                    Denominazione = "Prodotto 2",
                    Codice = 2,
                    Descrizione = "Descrizione",
                    Giacenza = 100,
                    Prezzo = 10.0
                },
                new Prodotto
                {
                    Denominazione = "Prodotto 3",
                    Codice = 3,
                    Descrizione = "Descrizione",
                    Giacenza = 100,
                    Prezzo = 10.0
                }
            };

        // GET: /Prodotti
        public IActionResult Index()
        {
            return View(lista);
        }

        // GET: /Prodotti/Details?codice=5
        public IActionResult Details(int? codice)
        {
            if (!codice.HasValue)
            {
                return NotFound();
            }

            var prodotto = lista.FirstOrDefault(p => p.Codice == codice);

            if (prodotto == null) {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: /Prodotti/delete?codice=5
        // creare il form per  visualizzare i dati e confermare l'eliminazione del prodotto
        public IActionResult Delete(int? codice)
        {
            if (!codice.HasValue)
            {
                return NotFound();
            }

            var prodotto = lista.FirstOrDefault(p => p.Codice == codice);

            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: /Prodotti/Delete?codice=5
        public IActionResult DeleteConfirmed(int? codice) {


            if (!codice.HasValue)
            {
                return NotFound("codice assente");
            }

            //lista.FindIndex(lista => lista.Codice == codice);
            var p = lista.FirstOrDefault(p => p.Codice == codice);

            if (p == null) {
                return NotFound("nessun prodotto con questo codice");
            }


            lista.Remove(p);

            //return View(p);
            return RedirectToAction(nameof(Index));
        }
    }
}
