using System;
using System.Collections.Generic;

namespace BikeStores.Data.Models;

public partial class OrderStatus
{
    public int IdStatus { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
