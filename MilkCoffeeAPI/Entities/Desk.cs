using System;
using System.Collections.Generic;

namespace MilkCoffeeAPI.Entities;

public partial class Desk
{
    public Guid TableId { get; set; }

    public int? Number { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
