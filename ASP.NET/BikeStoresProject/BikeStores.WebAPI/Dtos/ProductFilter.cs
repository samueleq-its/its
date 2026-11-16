namespace BikeStores.WebAPI.Dtos;

public class ProductFilter
{
    public string? Name { get; set; }          // ricerca parziale sul nome
    public int? BrandId { get; set; }
    public int? CategoryId { get; set; }
    public short? ModelYear { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? StoreId { get; set; }          // prodotti disponibili in quel negozio
    public bool? InStock { get; set; }         // solo prodotti con quantità > 0
    public string? SortBy { get; set; }        // name | price | year
    public bool Desc { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}