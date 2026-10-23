using GestioneVideotecaScolastica.Data;
using GestioneVideotecaScolastica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestioneVideotecaScolastica.Controllers
{
    [Authorize(Roles = "Administrators, Users")]
    public class FilmsController : Controller
    {
        private readonly GestioneVideotecaScolasticaContext _context;

        private readonly UserManager<IdentityUser> userManager;

        public FilmsController(GestioneVideotecaScolasticaContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        // GET: Films
        public async Task<IActionResult> Index(string? searchText)
        {
            var films = _context.Films.AsQueryable();

            //filtro i dati in base a cognome o nome o classe se searchText non è null
            if (searchText != null)
            {
                films = films.Where(x => x.Titolo!.Contains(searchText) || x.Regista!.Contains(searchText) || x.Attori!.Contains(searchText));

            }

            ViewBag.SearchText = searchText;
            return View(await films.Take(20).ToListAsync());
        }

        [AllowAnonymous]
        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Codice == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        [Authorize(Roles = "Users")]
        public async Task<IActionResult> Prenota(int codice)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var studente = await _context.Studenti.FirstOrDefaultAsync(s => s.Email == user.Email);

            if (studente == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(codice);
            if (film == null)
            {
                return NotFound();
            }
            var prestito = new Prestito { IdFilm = codice, Matricola = 1000, DataPrestito = DateTime.Now };

            _context.Prestiti.Add(prestito);
            await _context.SaveChangesAsync();

            ViewBag.Message = "Prenotazione effettuata con successo!";

            return RedirectToAction(nameof(Index));
        }


        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codice,Titolo,Supporto,Regista,Attori,Genere")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codice,Titolo,Supporto,Regista,Attori,Genere")] Film film)
        {
            if (id != film.Codice)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Codice))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Codice == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Codice == id);
        }
    }
}
