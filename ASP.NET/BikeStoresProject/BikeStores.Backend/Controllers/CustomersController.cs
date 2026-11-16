using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeStores.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace BikeStores.Backend.Controllers
{
    [Authorize(Roles = "ADMINISTRATOR,EMPLOYEES,CUSTOMERS")]
    public class CustomersController : Controller
    {
        private readonly BikeStoresContext _context;

        public CustomersController(BikeStoresContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = _context.Customers.AsQueryable();
            if (User.IsInRole("CUSTOMERS"))
            {
                var email = User.Identity?.Name ?? string.Empty;
                customers = customers.Where(c => c.Email == email);
            }

            return View(await customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await AccessibleCustomers()
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        [Authorize(Roles = "ADMINISTRATOR,EMPLOYEES")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRATOR,EMPLOYEES")]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Phone,Email,Street,City,State,ZipCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await AccessibleCustomers().FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Phone,Email,Street,City,State,ZipCode")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            if (!User.IsInRole("ADMINISTRATOR") &&
                !User.IsInRole("EMPLOYEES") &&
                !await AccessibleCustomers().AnyAsync(c => c.CustomerId == id))
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await AccessibleCustomers()
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRATOR,EMPLOYEES")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await AccessibleCustomers().FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        private IQueryable<Customer> AccessibleCustomers()
        {
            if (User.IsInRole("ADMINISTRATOR") || User.IsInRole("EMPLOYEES"))
            {
                return _context.Customers;
            }

            var email = User.Identity?.Name ?? string.Empty;
            return _context.Customers.Where(c => c.Email == email);
        }
    }
}
