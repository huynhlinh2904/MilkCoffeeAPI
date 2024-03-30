namespace MilkCoffeeAPI.Response
{
    public class ProductResponse
    {
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public Guid? CategoryId { get; set; } = default(Guid?);
        public string? CategoryName { get; set; }
    }
}
