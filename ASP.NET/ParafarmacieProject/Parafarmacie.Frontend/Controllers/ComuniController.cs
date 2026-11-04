using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parafarmacie.Data.Models;

namespace Parafarmacie.Frontend.Controllers
{
    public class ComuniController : Controller
    {
        private readonly ParafarmacieContext _context;

        public ComuniController(ParafarmacieContext context)
        {
            _context = context;
        }

        // GET: Parafarmacie
        public async Task<IActionResult> Index()
        {
            var parafarmacieContext = _context.Comuni.Include(c => c.IdProvinciaNavigation).Include(c => c.IdZonaAltimetricaNavigation).Include(c => c.IdZonaMontanaNavigation);
            return View(await parafarmacieContext.Take(20).ToListAsync());
        }

        // GET: Parafarmacie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comune = await _context.Comuni
                .Include(c => c.IdProvinciaNavigation)
                .Include(c => c.IdZonaAltimetricaNavigation)
                .Include(c => c.IdZonaMontanaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comune == null)
            {
                return NotFound();
            }

            return View(comune);
        }

        // GET: Parafarmacie/Create
        public IActionResult Create()
        {
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Denominazione");
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZoneAltimetriche, "Id", "Denominazione");
            ViewData["IdZonaMontana"] = new SelectList(_context.ZoneMontane, "Id", "Id");
            return View();
        }

        // POST: Parafarmacie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProvincia,Denominazione,CodiceCatastale,ComuneCapoluogo,AltitudineCentro,ZonaLitoranea,IdZonaAltimetrica,IdZonaMontana,Superficie,Popolazione2001,Popolazione2011")] Comune comune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Denominazione", comune.IdProvincia);
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZoneAltimetriche, "Id", "Denominazione", comune.IdZonaAltimetrica);
            ViewData["IdZonaMontana"] = new SelectList(_context.ZoneMontane, "Id", "Id", comune.IdZonaMontana);
            return View(comune);
        }

        // GET: Parafarmacie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comune = await _context.Comuni.FindAsync(id);
            if (comune == null)
            {
                return NotFound();
            }
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Denominazione", comune.IdProvincia);
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZoneAltimetriche, "Id", "Denominazione", comune.IdZonaAltimetrica);
            ViewData["IdZonaMontana"] = new SelectList(_context.ZoneMontane, "Id", "Id", comune.IdZonaMontana);
            return View(comune);
        }

        // POST: Parafarmacie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProvincia,Denominazione,CodiceCatastale,ComuneCapoluogo,AltitudineCentro,ZonaLitoranea,IdZonaAltimetrica,IdZonaMontana,Superficie,Popolazione2001,Popolazione2011")] Comune comune)
        {
            if (id != comune.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComuneExists(comune.Id))
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
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Denominazione", comune.IdProvincia);
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZoneAltimetriche, "Id", "Denominazione", comune.IdZonaAltimetrica);
            ViewData["IdZonaMontana"] = new SelectList(_context.ZoneMontane, "Id", "Id", comune.IdZonaMontana);
            return View(comune);
        }

        // GET: Parafarmacie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comune = await _context.Comuni
                .Include(c => c.IdProvinciaNavigation)
                .Include(c => c.IdZonaAltimetricaNavigation)
                .Include(c => c.IdZonaMontanaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comune == null)
            {
                return NotFound();
            }

            return View(comune);
        }

        // POST: Parafarmacie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comune = await _context.Comuni.FindAsync(id);
            if (comune != null)
            {
                _context.Comuni.Remove(comune);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComuneExists(int id)
        {
            return _context.Comuni.Any(e => e.Id == id);
        }
    }
}
