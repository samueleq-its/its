using GAM.Data;
using GAM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM.Controllers
{
    [Authorize]
    public class MaterialiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Materiali
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiale.ToListAsync());
        }

        // GET: Materiali/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiale = await _context.Materiale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiale == null)
            {
                return NotFound();
            }

            return View(materiale);
        }

        // GET: Materiali/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiali/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Denominazione")] Materiale materiale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiale);
        }

        // GET: Materiali/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiale = await _context.Materiale.FindAsync(id);
            if (materiale == null)
            {
                return NotFound();
            }
            return View(materiale);
        }

        // POST: Materiali/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denominazione")] Materiale materiale)
        {
            if (id != materiale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialeExists(materiale.Id))
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
            return View(materiale);
        }

        // GET: Materiali/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiale = await _context.Materiale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiale == null)
            {
                return NotFound();
            }

            return View(materiale);
        }

        // POST: Materiali/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiale = await _context.Materiale.FindAsync(id);
            if (materiale != null)
            {
                _context.Materiale.Remove(materiale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialeExists(int id)
        {
            return _context.Materiale.Any(e => e.Id == id);
        }
    }
}
