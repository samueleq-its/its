using BikeStores.Data.Models;
using BikeStores.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

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
        public async Task<IActionResult> Index(
            string? searchText,
            string orderBy = "name",
            int recordsPerPage = 20,
            int page = 1)
        {
            ViewData["recordsPerPage"] = recordsPerPage;
            ViewData["pages"] = 0;
            ViewBag.SearchText = searchText;
            orderBy = orderBy switch
            {
                "brand" => "brand",
                "category" => "category",
                "price" => "price",
                _ => "name"
            };
            ViewBag.OrderBy = orderBy;

            IQueryable<Product> bikeStoresContext = _context.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    ;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                bikeStoresContext = bikeStoresContext.Where(p =>
                    p.ProductName.Contains(searchText) ||
                    p.Brand.BrandName.Contains(searchText) ||
                    p.Category.CategoryName.Contains(searchText));
            }

            bikeStoresContext = orderBy switch
            {
                "brand" => bikeStoresContext.OrderBy(p => p.Brand.BrandName).ThenBy(p => p.ProductName),
                "category" => bikeStoresContext.OrderBy(p => p.Category.CategoryName).ThenBy(p => p.ProductName),
                "price" => bikeStoresContext.OrderBy(p => p.ListPrice).ThenBy(p => p.ProductName),
                _ => bikeStoresContext.OrderBy(p => p.ProductName)
            };

            var products = bikeStoresContext.Select(p => new ProductViewModel(p));

            if (recordsPerPage != 0)
            {
                ViewData["pages"] = (int)Math.Ceiling((double)products.Count() / recordsPerPage);
                products = products
                        .Skip((page - 1) * recordsPerPage)
                        .Take(recordsPerPage);
            }

            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(s => s.Brand)
                .Include(s => s.Category)
                .Include(p => p.Stocks)
                .ThenInclude(s => s.Store)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductViewModel(product));
        }
    }
}
