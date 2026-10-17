using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScuoleItaliane.Models;

namespace ScuoleItaliane.Controllers
{
    public class RegioniController : Controller
    {
        private readonly ScuoleItalianeContext _context;

        public RegioniController(ScuoleItalianeContext context)
        {
            _context = context;
        }

        // GET: Regioni
        public async Task<IActionResult> Index()
        {
            var scuoleItalianeContext = _context.Regioni
                .Include(r => r.IdRipartizioneNavigation)
                .Include(r => r.Provincie)
                .ThenInclude(p => p.Comuni)
                .ThenInclude(c => c.Scuole)
                .OrderBy(r => r.Denominazione)
                ;

            return View(await scuoleItalianeContext.ToListAsync());
        }

        //// GET: Regioni/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var regione = await _context.Regioni
        //        .Include(r => r.IdRipartizioneNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (regione == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(regione);
        //}

        private bool RegioneExists(int id)
        {
            return _context.Regioni.Any(e => e.Id == id);
        }
    }
}
