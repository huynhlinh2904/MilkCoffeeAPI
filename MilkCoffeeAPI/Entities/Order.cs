using System;
using System.Collections.Generic;

namespace MilkCoffeeAPI.Entities;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid? TableId { get; set; }

    public DateTime? Day { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Desk? Table { get; set; }
}
