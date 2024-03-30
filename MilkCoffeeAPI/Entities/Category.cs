using System;
using System.Collections.Generic;

namespace MilkCoffeeAPI.Entities;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
