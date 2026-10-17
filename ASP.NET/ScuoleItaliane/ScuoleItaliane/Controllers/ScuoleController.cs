using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ScuoleItaliane.Models;

namespace ScuoleItaliane.Controllers
{
    public class ScuoleController : Controller
    {
        private readonly ScuoleItalianeContext _context;

        public ScuoleController(ScuoleItalianeContext context)
        {
            _context = context;
        }

        // GET: Scuole
        public async Task<IActionResult> Index(String? nomeScuola, bool onlyLitoranei = false, string regione = "", string comune = "", int page = 1)
        {
            const int RECORDS_PER_PAGE = 50;

            var scuoleItalianeContext = _context.Scuole.Include(s => s.IdCaratteristicaScuolaNavigation).Include(s => s.IdComuneNavigation).Include(s => s.IdIstitutoRiferimentoNavigation).Include(s => s.IdTipologiaScuolaNavigation);

            var ctx = scuoleItalianeContext.AsQueryable();

            if(nomeScuola != null){
                ctx = ctx.Where(s => s.Denominazione.Contains(nomeScuola));
            }

            if (onlyLitoranei)
            {
                ctx = ctx.Where(s => s.IdComuneNavigation.ComuneLitoraneo);
            }

            if (regione != "")
            {
                ctx = ctx.Where(s => s.IdComuneNavigation.IdProvinciaNavigation.IdRegioneNavigation.Denominazione.Equals(regione));
            }

            if (comune != "")
            {
                ctx = ctx.Where(s => s.IdComuneNavigation.Denominazione.Equals(comune));
            }

            ViewData["Title"] = "Elenco Scuole";
            ViewData["page"] = page;
            ViewData["nomeScuola"] = nomeScuola;
            ViewData["onlyLitoranei"] = onlyLitoranei;
            ViewData["regione"] = regione;
            ViewData["comune"] = comune;

            ViewData["listaRegioni"] = getRegioni();
            ViewData["listaComuni"] = getComuni();

            ViewData["pagesNumber"] = (int)Math.Ceiling((double)ctx.Count() / RECORDS_PER_PAGE);

            ctx = ctx.OrderBy(s => s.Denominazione).Skip((page - 1) * RECORDS_PER_PAGE).Take(RECORDS_PER_PAGE);

            return View(await ctx.ToListAsync());
        }

        public async Task<IActionResult> ScuoleRegione(int? id)
        {
            var scuoleItalianeContext = _context.Scuole.Include(s => s.IdCaratteristicaScuolaNavigation).Include(s => s.IdComuneNavigation).Include(s => s.IdIstitutoRiferimentoNavigation).Include(s => s.IdTipologiaScuolaNavigation);

            var ctx = scuoleItalianeContext.AsQueryable()
                .Where(s => s.IdComuneNavigation.IdProvinciaNavigation.IdRegioneNavigation.Id == id)
                .OrderBy(s => s.Denominazione)
                ;

            var regione = _context.Regioni.Find(id);

            ViewData["Title"] = $"Elenco Scuole in {regione?.Denominazione}";

            return View(await ctx.ToListAsync());
        }

        // GET: Scuole/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scuola = await _context.Scuole
                .Include(s => s.IdCaratteristicaScuolaNavigation)
                .Include(s => s.IdComuneNavigation)
                .Include(s => s.IdIstitutoRiferimentoNavigation)
                .Include(s => s.IdTipologiaScuolaNavigation)
                .FirstOrDefaultAsync(m => m.CodiceScuola == id);
            if (scuola == null)
            {
                return NotFound();
            }

            return View(scuola);
        }

        private List<String> getRegioni()
        {
            return _context.Regioni.Select(r => r.Denominazione).Order().ToList();
        }

        private List<String> getComuni()
        {
            return _context.Comuni.Where(c => c.Scuole.Count > 0).Select(c => c.Denominazione).Order().ToList();
        }

        private bool ScuolaExists(string id)
        {
            return _context.Scuole.Any(e => e.CodiceScuola == id);
        }
    }
}
