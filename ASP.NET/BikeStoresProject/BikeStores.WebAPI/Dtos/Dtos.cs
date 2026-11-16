namespace BikeStores.WebAPI.Dtos;

public record BrandDto(int BrandId, string BrandName);
public record CategoryDto(int CategoryId, string CategoryName);

public record ProductDto(int ProductId, string ProductName, int BrandId, string BrandName,
    int CategoryId, string CategoryName, short ModelYear, decimal ListPrice);

public record StockDto(int StoreId, string StoreName, int Quantity);

public record ProductDetailDto(int ProductId, string ProductName, int BrandId, string BrandName,
    int CategoryId, string CategoryName, short ModelYear, decimal ListPrice,
    List<StockDto> Stocks);

public record StoreDto(int StoreId, string StoreName, string? Phone, string? Email,
    string? Street, string? City, string? State, string? ZipCode);

public record StaffDto(int StaffId, string FirstName, string LastName, string Email,
    string? Phone, bool Active, int StoreId);

public record CustomerDto(int CustomerId, string FirstName, string LastName, string? Phone,
    string Email, string? Street, string? City, string? State, string? ZipCode);

public record OrderItemDto(int ItemId, int ProductId, string ProductName, int Quantity,
    decimal ListPrice, decimal Discount, decimal Total);

public record OrderDto(int OrderId, int? CustomerId, int OrderStatusId, string? StatusName,
    DateOnly OrderDate, DateOnly RequiredDate, DateOnly? ShippedDate,
    int StoreId, string StoreName, int StaffId, decimal Total);

public record OrderDetailDto(int OrderId, int? CustomerId, int OrderStatusId, string? StatusName,
    DateOnly OrderDate, DateOnly RequiredDate, DateOnly? ShippedDate,
    int StoreId, string StoreName, int StaffId, decimal Total, List<OrderItemDto> Items);

public class PagedResult<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public List<T> Items { get; set; } = new();
}