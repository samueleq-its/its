using BikeStores.Data.Models;
using BikeStores.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoresController : ControllerBase
{
    private readonly BikeStoresContext _context;
    public StoresController(BikeStoresContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<List<StoreDto>>> GetAll() =>
        await _context.Stores.AsNoTracking().OrderBy(s => s.StoreName)
            .Select(s => new StoreDto(s.StoreId, s.StoreName, s.Phone, s.Email,
                s.Street, s.City, s.State, s.ZipCode)).ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StoreDto>> GetById(int id)
    {
        var store = await _context.Stores.AsNoTracking().Where(s => s.StoreId == id)
            .Select(s => new StoreDto(s.StoreId, s.StoreName, s.Phone, s.Email,
                s.Street, s.City, s.State, s.ZipCode)).FirstOrDefaultAsync();
        return store is null ? NotFound() : store;
    }

    // GET api/stores/1/staff
    [HttpGet("{id:int}/staff")]
    public async Task<ActionResult<List<StaffDto>>> GetStaff(int id)
    {
        if (!await _context.Stores.AnyAsync(s => s.StoreId == id)) return NotFound();

        return await _context.Staffs.AsNoTracking().Where(s => s.StoreId == id && s.Active == 1)
            .OrderBy(s => s.LastName)
            .Select(s => new StaffDto(s.StaffId, s.FirstName, s.LastName, s.Email,
                s.Phone, s.Active == 1, s.StoreId)).ToListAsync();
    }

    // GET api/stores/1/stocks  -> disponibilità prodotti nel negozio
    [HttpGet("{id:int}/stocks")]
    public async Task<ActionResult<List<StockDto>>> GetStocks(int id)
    {
        if (!await _context.Stores.AnyAsync(s => s.StoreId == id)) return NotFound();

        return await _context.Stocks.AsNoTracking().Where(s => s.StoreId == id)
            .Select(s => new StockDto(s.ProductId, s.Product.ProductName, s.Quantity ?? 0)).ToListAsync();
    }
}