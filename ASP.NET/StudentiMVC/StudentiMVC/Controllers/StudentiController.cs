using Microsoft.AspNetCore.Mvc;
using StudentiMVC.Models;

namespace StudentiMVC.Controllers
{
    public class StudentiController : Controller
    {

        public const string studentiCsv = @"C:\Users\samuele.querio\Documents\GitHub\its\ASP.NET\StudentiMVC\StudentiMVC\File\Studenti.csv";
        private List<Studente> elenco = MyLibrary.LeggiStudenti(studentiCsv);

        /*static List<Studente> elenco = new List<Studente>() {

                new Studente{ Matricola=12345,Cognome="Di Luigi", Nome="Stefano", Email="ppp@itis.net",Classe="1A" },

                new Studente{ Matricola=12346,Cognome="Di Giuseppe", Nome="Giuseppe", Email="pp1@itis.net",Classe="2A" },

                new Studente{ Matricola=12347,Cognome="Di Stena", Nome="Liugi", Email="pp2@itis.net",Classe="3B" },

                new Studente{ Matricola=12348,Cognome="Di Luca", Nome="Angela", Email="pp3@itis.net",Classe="4C" },

                new Studente{ Matricola=12349,Cognome="Di Dennis", Nome="Laura", Email="pp4@itis.net",Classe="5D" }
        };*/


        // GET: StudentiController
        public ActionResult Index()
        {
            return View(elenco);
        }

        // GET: StudentiController/Details/5
        public ActionResult Details(int? matricola)
        {
            if (!matricola.HasValue)
            {
                return NotFound();
            }

            Studente? s = elenco.FirstOrDefault(s => s.Matricola == matricola);

            if (s == null)
            {
                return NotFound();
            }

            return View(s);
        }

        // GET: StudentiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Studente studente) //IFormCollection collection
        {
            // controllo studente == null?

            elenco.Add(studente);
            MyLibrary.ScriviStudenti(studentiCsv, elenco);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentiController/Edit/5
        public ActionResult Edit(int? matricola)
        {
            Studente? s = elenco.FirstOrDefault(s => s.Matricola == matricola);

            if (s == null)
            {
                return NotFound();
            }

            return View(s);
        }

        // POST: StudentiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int matricola, Studente s)
        {
            int index = elenco.FindIndex(s => s.Matricola == matricola);

            if (index == -1) // matricola != s.Matricola 
            {
                return NotFound();
            }

            elenco[index] = s;
            MyLibrary.ScriviStudenti(studentiCsv, elenco);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentiController/Delete/5
        public ActionResult Delete(int? matricola)
        {

            Studente? s = elenco.FirstOrDefault(s => s.Matricola == matricola);

            if (s == null)
            {
                return NotFound();
            }

            return View(s);
        }

        // POST: StudentiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int matricola)
        {

            int index = elenco.FindIndex(s => s.Matricola == matricola);

            if (index == -1)
            {
                return NotFound();
            }

            elenco.RemoveAt(index);
            MyLibrary.ScriviStudenti(studentiCsv, elenco);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    
    }
}


/*
TODO:
index non deve mostrare tutti i dati
edit non deve permettere di modificare la matricola?
 
 */