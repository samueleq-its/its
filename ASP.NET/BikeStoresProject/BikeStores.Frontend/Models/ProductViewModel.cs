using BikeStores.Data.Models;
using System.ComponentModel;

namespace BikeStores.Frontend.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [DisplayName("Product")]
        public string ProductName { get; set; }
        [DisplayName("Brand")]
        public string BrandName { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        [DisplayName("Price")]
        public decimal ListPrice { get; set; }
        [DisplayName("Production year")]
        public short ModelYear { get; set; }
        public int? Quantity { get; set; }
        public Dictionary<String, int> StoresQuantity { get; set; }


        public ProductViewModel(Product p)
        {
            ProductId = p.ProductId;
            ProductName = p.ProductName;
            BrandName = p.Brand.BrandName;
            CategoryName = p.Category.CategoryName;
            ListPrice = p.ListPrice;
            ModelYear = p.ModelYear;
            Quantity = p.Stocks.Aggregate(0, (acc, s) => acc + s.Quantity ?? 0);
            StoresQuantity = p.Stocks.ToDictionary(
                s => s.Store.StoreName,
                s => s.Quantity ?? 0);
        }
    }
}
