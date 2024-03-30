using System;
using System.Collections.Generic;

namespace MilkCoffeeAPI.Entities;

public partial class Image
{
    public Guid ImageId { get; set; }

    public string? ImageUrl { get; set; }

    public string? PublicId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
