using System;
using System.Collections.Generic;

namespace MilkCoffeeAPI.Entities;

public partial class OrderDetail
{
    public Guid OrderDetailId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Amount { get; set; }

    public double? Discount { get; set; }

    public double? Total { get; set; }

    public Guid? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
