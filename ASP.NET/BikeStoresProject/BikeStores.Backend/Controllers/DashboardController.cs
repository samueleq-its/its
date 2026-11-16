using Microsoft.AspNetCore.Mvc;

namespace BikeStores.Backend.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
