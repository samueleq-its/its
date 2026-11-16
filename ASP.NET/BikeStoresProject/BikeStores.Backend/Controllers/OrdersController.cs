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
    [Authorize(Roles = "ADMINISTRATORS,EMPLOYEES,CUSTOMERS")]
    public class OrdersController : Controller
    {
        private readonly BikeStoresContext _context;

        public OrdersController(BikeStoresContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(
            string? searchText,
            int? statusId,
            string orderBy = "date",
            int page = 1,
            int pageSize = 20)
        {
            var orders = AccessibleOrders();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                orders = orders.Where(o =>
                    (o.Customer != null && o.Customer.Email.Contains(searchText)) ||
                    o.Staff.Email.Contains(searchText) ||
                    o.Store.StoreName.Contains(searchText) ||
                    o.OrderId.ToString().Contains(searchText));
            }
            if (statusId.HasValue)
            {
                orders = orders.Where(o => o.OrderStatusId == statusId.Value);
            }

            orders = orderBy switch
            {
                "customer" => orders.OrderBy(o => o.Customer!.LastName).ThenByDescending(o => o.OrderDate),
                "status" => orders.OrderBy(o => o.OrderStatus.StatusName).ThenByDescending(o => o.OrderDate),
                _ => orders.OrderByDescending(o => o.OrderDate)
            };

            ViewBag.SearchText = searchText;
            ViewBag.StatusId = statusId;
            ViewBag.OrderBy = orderBy;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(await orders.CountAsync() / (double)pageSize);
            ViewBag.Statuses = await _context.OrderStatuses.OrderBy(s => s.StatusName).ToListAsync();

            return View(await orders.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await AccessibleOrders()
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus)
                .Include(o => o.Staff)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        [Authorize(Roles = "ADMINISTRATORS,EMPLOYEES")]
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "IdStatus", "IdStatus");
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Email");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRATORS,EMPLOYEES")]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderStatusId,OrderDate,RequiredDate,ShippedDate,StoreId,StaffId")] Order order)
        {
            if (User.IsInRole("EMPLOYEES"))
            {
                var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Email == User.Identity!.Name);
                if (staff == null)
                {
                    return Forbid();
                }

                order.StaffId = staff.StaffId;
            }

            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "IdStatus", "IdStatus", order.OrderStatusId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Email", order.StaffId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", order.StoreId);
            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "ADMINISTRATORS,EMPLOYEES")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await AccessibleOrders().FirstOrDefaultAsync(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "IdStatus", "IdStatus", order.OrderStatusId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Email", order.StaffId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", order.StoreId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRATORS,EMPLOYEES")]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderStatusId,OrderDate,RequiredDate,ShippedDate,StoreId,StaffId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            var existingOrder = await AccessibleOrders()
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            if (User.IsInRole("EMPLOYEES"))
            {
                order.StaffId = existingOrder.StaffId;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "IdStatus", "IdStatus", order.OrderStatusId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Email", order.StaffId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", order.StoreId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await AccessibleOrders()
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus)
                .Include(o => o.Staff)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRATORS,EMPLOYEES")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await AccessibleOrders().FirstOrDefaultAsync(o => o.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

        private IQueryable<Order> AccessibleOrders()
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus)
                .Include(o => o.Staff)
                .Include(o => o.Store)
                .Include(o => o.OrderItems)
                    .ThenInclude(item => item.Product)
                .AsQueryable();

            if (User.IsInRole("ADMINISTRATORS"))
            {
                return orders;
            }

            var email = User.Identity?.Name ?? string.Empty;
            if (User.IsInRole("EMPLOYEES"))
            {
                return orders.Where(o => o.Staff.Email == email);
            }

            return orders.Where(o => o.Customer != null && o.Customer.Email == email);
        }
    }
}
