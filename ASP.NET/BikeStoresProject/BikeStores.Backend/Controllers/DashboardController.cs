using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BikeStores.Backend.Services;
using BikeStores.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Backend.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly BikeStoresContext _context;
        private readonly LoginHistoryStore _loginHistory;

        public DashboardController(BikeStoresContext context, LoginHistoryStore loginHistory)
        {
            _context = context;
            _loginHistory = loginHistory;
        }

        public async Task<IActionResult> Index()
        {
            var email = User.Identity?.Name ?? string.Empty;
            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Email == email);
            var customer = staff == null
                ? await _context.Customers.FirstOrDefaultAsync(c => c.Email == email)
                : null;
            var name = staff?.FirstName ?? customer?.FirstName ?? User.FindFirstValue(ClaimTypes.GivenName) ?? email;
            var surname = staff?.LastName ?? customer?.LastName ?? User.FindFirstValue(ClaimTypes.Surname) ?? string.Empty;
            var allLogins = await _loginHistory.GetAllAsync();
            var logins = User.IsInRole("ADMINISTRATOR")
                ? allLogins
                : allLogins.Where(login => login.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).Take(10).ToList();

            return View(new DashboardViewModel(name, surname, logins, User.IsInRole("ADMINISTRATOR")));
        }
    }

    public sealed record DashboardViewModel(
        string Name,
        string Surname,
        IReadOnlyList<LoginRecord> Logins,
        bool IsAdministrator);
}
