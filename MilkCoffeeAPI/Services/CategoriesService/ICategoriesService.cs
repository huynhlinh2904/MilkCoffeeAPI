using MilkCoffeeAPI.Core;
using MilkCoffeeAPI.Models.Response;
using MilkCoffeeAPI.Models.Resquest;

namespace MilkCoffeeAPI.Services.CategoriesService
{
    public interface ICategoriesService
    {
        public Task<APIResponse<IEnumerable<CategoryResponse>>> GetCategoriesAsync();

        public Task<APIResponse<CategoryResponse>> CreateCategory(CategoryRequest request);

        public Task<APIResponse<CategoryResponse>> UpdateCategory(Guid? id, CategoryRequest request);
    }
}
