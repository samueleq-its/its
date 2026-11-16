using BikeStores.Data.Models;
using BikeStores.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly BikeStoresContext _context;
    public ProductsController(BikeStoresContext context) => _context = context;

    // GET api/products?name=trek&brandId=9&minPrice=500&inStock=true&sortBy=price&page=1
    [HttpGet]
    public async Task<ActionResult<PagedResult<ProductDto>>> Search([FromQuery] ProductFilter f)
    {
        var page = Math.Max(f.Page, 1);
        var pageSize = Math.Clamp(f.PageSize, 1, 100);

        var query = _context.Products.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(f.Name))
            query = query.Where(p => p.ProductName.Contains(f.Name));
        if (f.BrandId.HasValue)
            query = query.Where(p => p.BrandId == f.BrandId);
        if (f.CategoryId.HasValue)
            query = query.Where(p => p.CategoryId == f.CategoryId);
        if (f.ModelYear.HasValue)
            query = query.Where(p => p.ModelYear == f.ModelYear);
        if (f.MinPrice.HasValue)
            query = query.Where(p => p.ListPrice >= f.MinPrice);
        if (f.MaxPrice.HasValue)
            query = query.Where(p => p.ListPrice <= f.MaxPrice);
        if (f.StoreId.HasValue || f.InStock == true)
            query = query.Where(p => p.Stocks.Any(s =>
                (!f.StoreId.HasValue || s.StoreId == f.StoreId) && s.Quantity > 0));

        query = (f.SortBy?.ToLower(), f.Desc) switch
        {
            ("price", false) => query.OrderBy(p => p.ListPrice),
            ("price", true) => query.OrderByDescending(p => p.ListPrice),
            ("year", false) => query.OrderBy(p => p.ModelYear),
            ("year", true) => query.OrderByDescending(p => p.ModelYear),
            (_, true) => query.OrderByDescending(p => p.ProductName),
            _ => query.OrderBy(p => p.ProductName)
        };

        var total = await query.CountAsync();
        var items = await query
            .Skip((page - 1) * pageSize).Take(pageSize)
            .Select(p => new ProductDto(p.ProductId, p.ProductName, p.BrandId, p.Brand.BrandName,
                p.CategoryId, p.Category.CategoryName, p.ModelYear, p.ListPrice))
            .ToListAsync();

        return new PagedResult<ProductDto> { Page = page, PageSize = pageSize, TotalCount = total, Items = items };
    }

    // GET api/products/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDetailDto>> GetById(int id)
    {
        var product = await _context.Products.AsNoTracking()
            .Where(p => p.ProductId == id)
            .Select(p => new ProductDetailDto(p.ProductId, p.ProductName, p.BrandId, p.Brand.BrandName,
                p.CategoryId, p.Category.CategoryName, p.ModelYear, p.ListPrice,
                p.Stocks.Select(s => new StockDto(s.StoreId, s.Store.StoreName, s.Quantity ?? 0)).ToList()))
            .FirstOrDefaultAsync();

        return product is null ? NotFound() : product;
    }
}