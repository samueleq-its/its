using BikeStores.Data.Models;
using BikeStores.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly BikeStoresContext _context;
    public CategoriesController(BikeStoresContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAll() =>
        await _context.Categories.AsNoTracking().OrderBy(c => c.CategoryName)
            .Select(c => new CategoryDto(c.CategoryId, c.CategoryName)).ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDto>> GetById(int id)
    {
        var cat = await _context.Categories.AsNoTracking().Where(c => c.CategoryId == id)
            .Select(c => new CategoryDto(c.CategoryId, c.CategoryName)).FirstOrDefaultAsync();
        return cat is null ? NotFound() : cat;
    }
}