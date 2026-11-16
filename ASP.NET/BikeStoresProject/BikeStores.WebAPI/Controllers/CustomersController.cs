using BikeStores.Data.Models;
using BikeStores.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly BikeStoresContext _context;
    public CustomersController(BikeStoresContext context) => _context = context;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var c = await _context.Customers.AsNoTracking().Where(x => x.CustomerId == id)
            .Select(x => new CustomerDto(x.CustomerId, x.FirstName, x.LastName, x.Phone,
                x.Email, x.Street, x.City, x.State, x.ZipCode)).FirstOrDefaultAsync();
        return c is null ? NotFound() : c;
    }

    // GET api/customers/by-email?email=...  (utile per il "login" dell'app mobile)
    [HttpGet("by-email")]
    public async Task<ActionResult<CustomerDto>> GetByEmail([FromQuery] string email)
    {
        var c = await _context.Customers.AsNoTracking().Where(x => x.Email == email)
            .Select(x => new CustomerDto(x.CustomerId, x.FirstName, x.LastName, x.Phone,
                x.Email, x.Street, x.City, x.State, x.ZipCode)).FirstOrDefaultAsync();
        return c is null ? NotFound() : c;
    }

    // GET api/customers/3/orders
    [HttpGet("{id:int}/orders")]
    public async Task<ActionResult<List<OrderDto>>> GetOrders(int id)
    {
        if (!await _context.Customers.AnyAsync(c => c.CustomerId == id)) return NotFound();

        return await _context.Orders.AsNoTracking().Where(o => o.CustomerId == id)
            .OrderByDescending(o => o.OrderDate)
            .Select(o => new OrderDto(o.OrderId, o.CustomerId, o.OrderStatusId, o.OrderStatus.StatusName,
                o.OrderDate, o.RequiredDate, o.ShippedDate, o.StoreId, o.Store.StoreName, o.StaffId,
                o.OrderItems.Sum(i => i.Quantity * i.ListPrice * (1 - i.Discount))))
            .ToListAsync();
    }
}