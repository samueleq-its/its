using BikeStores.Data.Models;
using BikeStores.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly BikeStoresContext _context;
    public BrandsController(BikeStoresContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<List<BrandDto>>> GetAll() =>
        await _context.Brands.AsNoTracking().OrderBy(b => b.BrandName)
            .Select(b => new BrandDto(b.BrandId, b.BrandName)).ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BrandDto>> GetById(int id)
    {
        var brand = await _context.Brands.AsNoTracking().Where(b => b.BrandId == id)
            .Select(b => new BrandDto(b.BrandId, b.BrandName)).FirstOrDefaultAsync();
        return brand is null ? NotFound() : brand;
    }
}