using System;
using System.Collections.Generic;

namespace MilkCoffeeAPI.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string? ProductName { get; set; }

    public double? ProductPrice { get; set; }

    public string? Description { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? ImageId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
