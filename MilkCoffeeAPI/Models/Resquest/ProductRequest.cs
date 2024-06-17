namespace MilkCoffeeAPI.Models.Resquest
{
    public class ProductRequest
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? CategoryName { get; set; }

        public double? Price { get; set; }

        public Guid? ImageId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
