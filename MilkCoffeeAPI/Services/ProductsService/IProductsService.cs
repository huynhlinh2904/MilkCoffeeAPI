using MilkCoffeeAPI.Core;
using MilkCoffeeAPI.Models.Response;
using MilkCoffeeAPI.Models.Resquest;

namespace MilkCoffeeAPI.Services.ProductsService
{
    public interface IProductsService
    {
        public Task<APIResponse<ProductResponse>> CreateProduct(ProductRequest request);
        public Task<APIResponse<IEnumerable<ProductResponse>>> GetProductByCategoryId(Guid? categoryId);

        public Task<APIResponse<ProductResponse>> UpdateProduct(Guid? productId, ProductRequest request);
    }
}
