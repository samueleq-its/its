using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GAM.Data;
using GAM.Models;
using Microsoft.AspNetCore.Authorization;

namespace GAM.Controllers
{
    [Authorize]
    public class OpereController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpereController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: Opere
        public async Task<IActionResult> Index()
        {
            var elencoViewModel = (from o in _context.Opera.Take(200)
                                         join a in _context.Autore on o.IdAutore equals a.Id into autoriGroup
                                         from a in autoriGroup.DefaultIfEmpty()
                                         select new OperaViewModel
                                         {
                                             Inventario = o.Inventario,
                                             // Se l'autore esiste concatena Nome e Cognome, altrimenti imposta un valore di fallback
                                             Autore = a != null ? $"{a.Nominativo}" : "Sconosciuto",
                                             Datazione = o.Datazione,
                                             Titolo = o.TitoloSoggetto,
                                             Immagine = o.Immagine
                                         });
            return View(await elencoViewModel.ToListAsync());
        }

        [AllowAnonymous]
        // GET: Opere/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opera = await _context.Opera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opera == null)
            {
                return NotFound();
            }

            return View(opera);
        }

        // GET: Opere/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opere/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Inventario,IdAutore,AmbitoCulturale,Datazione,TitoloSoggetto,Immagine,Lsreferenceby")] Opera opera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opera);
        }

        // GET: Opere/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opera = await _context.Opera.FindAsync(id);
            if (opera == null)
            {
                return NotFound();
            }
            return View(opera);
        }

        // POST: Opere/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Inventario,IdAutore,AmbitoCulturale,Datazione,TitoloSoggetto,Immagine,Lsreferenceby")] Opera opera)
        {
            if (id != opera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperaExists(opera.Id))
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
            return View(opera);
        }

        // GET: Opere/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opera = await _context.Opera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opera == null)
            {
                return NotFound();
            }

            return View(opera);
        }

        // POST: Opere/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opera = await _context.Opera.FindAsync(id);
            if (opera != null)
            {
                _context.Opera.Remove(opera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperaExists(int id)
        {
            return _context.Opera.Any(e => e.Id == id);
        }
    }
}
