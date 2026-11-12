using BikeStores.Data.Models;
using BikeStores.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Frontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BikeStoresContext _context;

        public ProductsController(BikeStoresContext context)
        {
            _context = context;
        }


        // GET: Products
        public async Task<IActionResult> Index()
        {
            var bikeStoresContext = _context.Products.Include(p => p.Brand).Include(p => p.Category).OrderBy(p => p.ProductName).Select(p => new ProductViewModel(p));
            return View(await bikeStoresContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks
                .Include(s => s.Product)
                .ThenInclude(p => p.Brand)
                .Include(s => s.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(new ProductViewModel(stock));
        }
    }
}
