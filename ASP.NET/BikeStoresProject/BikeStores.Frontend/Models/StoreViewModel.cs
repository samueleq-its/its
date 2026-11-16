using BikeStores.Data.Models;
using System.ComponentModel;

namespace BikeStores.Frontend.Models
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        [DisplayName("Store")]
        public string StoreName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("ZIP code")]
        public string? ZipCode { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        public StoreViewModel(Store store)
        {
            StoreId = store.StoreId;
            StoreName = store.StoreName;
            Phone = store.Phone;
            Email = store.Email;
            Street = store.Street;
            City = store.City;
            State = store.State;
            ZipCode = store.ZipCode;
            Employees = store.Staff
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .Select(s => new EmployeeViewModel(s));
        }
    }
}
