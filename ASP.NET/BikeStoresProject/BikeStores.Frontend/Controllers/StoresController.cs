using BikeStores.Data.Models;
using BikeStores.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Frontend.Controllers
{
    public class StoresController : Controller
    {
        private readonly BikeStoresContext _context;

        public StoresController(BikeStoresContext context)
        {
            _context = context;
        }

        // GET: Stores
        public async Task<IActionResult> Index()
        {
            var stores = await _context.Stores
                .Include(s => s.Staff)
                .OrderBy(s => s.StoreName)
                .ToListAsync();

            return View(stores.Select(s => new StoreViewModel(s)));
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(new StoreViewModel(store));
        }

    }
}
