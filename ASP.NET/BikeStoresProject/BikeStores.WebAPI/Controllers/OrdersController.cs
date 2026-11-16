using BikeStores.Data.Models;
using BikeStores.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly BikeStoresContext _context;
    public OrdersController(BikeStoresContext context) => _context = context;

    // GET api/orders/10  -> ordine con righe
    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDetailDto>> GetById(int id)
    {
        var o = await _context.Orders.AsNoTracking().Where(x => x.OrderId == id)
            .Select(x => new OrderDetailDto(x.OrderId, x.CustomerId, x.OrderStatusId,
                x.OrderStatus.StatusName, x.OrderDate, x.RequiredDate, x.ShippedDate,
                x.StoreId, x.Store.StoreName, x.StaffId,
                x.OrderItems.Sum(i => i.Quantity * i.ListPrice * (1 - i.Discount)),
                x.OrderItems.Select(i => new OrderItemDto(i.ItemId, i.ProductId, i.Product.ProductName,
                    i.Quantity, i.ListPrice, i.Discount,
                    i.Quantity * i.ListPrice * (1 - i.Discount))).ToList()))
            .FirstOrDefaultAsync();

        return o is null ? NotFound() : o;
    }

    // GET api/orders?statusId=4&storeId=1&page=1&pageSize=20
    [HttpGet]
    public async Task<ActionResult<PagedResult<OrderDto>>> Search(
        [FromQuery] int? statusId, [FromQuery] int? storeId,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var query = _context.Orders.AsNoTracking().AsQueryable();
        if (statusId.HasValue) query = query.Where(o => o.OrderStatusId == statusId);
        if (storeId.HasValue) query = query.Where(o => o.StoreId == storeId);

        var total = await query.CountAsync();
        var items = await query.OrderByDescending(o => o.OrderDate)
            .Skip((page - 1) * pageSize).Take(pageSize)
            .Select(o => new OrderDto(o.OrderId, o.CustomerId, o.OrderStatusId, o.OrderStatus.StatusName,
                o.OrderDate, o.RequiredDate, o.ShippedDate, o.StoreId, o.Store.StoreName, o.StaffId,
                o.OrderItems.Sum(i => i.Quantity * i.ListPrice * (1 - i.Discount))))
            .ToListAsync();

        return new PagedResult<OrderDto> { Page = page, PageSize = pageSize, TotalCount = total, Items = items };
    }
}