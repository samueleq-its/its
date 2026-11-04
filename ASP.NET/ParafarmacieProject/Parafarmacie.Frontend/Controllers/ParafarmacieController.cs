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
    public class ParafarmacieController : Controller
    {
        private readonly ParafarmacieContext _context;

        public ParafarmacieController(ParafarmacieContext context)
        {
            _context = context;
        }

        // GET: Parafarmacie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parafarmacie.Take(20).ToListAsync());
        }

        // GET: Parafarmacie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parafarmacia = await _context.Parafarmacie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parafarmacia == null)
            {
                return NotFound();
            }

            return View(parafarmacia);
        }

        // GET: Parafarmacie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parafarmacie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodiceIdentificativoSito,SitoLogistico,Indirizzo,PartitaIva,Cap,IdComune,DataInizioValidita,DataFineValidita,Latitudine,Longitudine,Localizzazione")] Parafarmacia parafarmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parafarmacia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parafarmacia);
        }

        // GET: Parafarmacie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parafarmacia = await _context.Parafarmacie.FindAsync(id);
            if (parafarmacia == null)
            {
                return NotFound();
            }
            return View(parafarmacia);
        }

        // POST: Parafarmacie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodiceIdentificativoSito,SitoLogistico,Indirizzo,PartitaIva,Cap,IdComune,DataInizioValidita,DataFineValidita,Latitudine,Longitudine,Localizzazione")] Parafarmacia parafarmacia)
        {
            if (id != parafarmacia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parafarmacia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParafarmaciaExists(parafarmacia.Id))
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
            return View(parafarmacia);
        }

        // GET: Parafarmacie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parafarmacia = await _context.Parafarmacie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parafarmacia == null)
            {
                return NotFound();
            }

            return View(parafarmacia);
        }

        // POST: Parafarmacie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parafarmacia = await _context.Parafarmacie.FindAsync(id);
            if (parafarmacia != null)
            {
                _context.Parafarmacie.Remove(parafarmacia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParafarmaciaExists(int id)
        {
            return _context.Parafarmacie.Any(e => e.Id == id);
        }
    }
}
