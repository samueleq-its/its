using BikeStores.Data.Models;
using System.ComponentModel;

namespace BikeStores.Frontend.Models
{
    public class EmployeeViewModel
    {
        public int StaffId { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; } = null!;
        [DisplayName("Last name")]
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public byte Active { get; set; }
        public int StoreId { get; set; }
        public int? ManagerId { get; set; }

        public EmployeeViewModel(Staff staff)
        {
            StaffId = staff.StaffId;
            FirstName = staff.FirstName;
            LastName = staff.LastName;
            Email = staff.Email;
            Phone = staff.Phone;
            Active = staff.Active;
            StoreId = staff.StoreId;
            ManagerId = staff.ManagerId;
        }
    }
}
