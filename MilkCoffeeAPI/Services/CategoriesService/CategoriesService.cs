using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkCoffeeAPI.Core;
using MilkCoffeeAPI.Entities;
using MilkCoffeeAPI.Models.Response;
using MilkCoffeeAPI.Models.Resquest;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MilkCoffeeAPI.Services.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly MilkCoffeeContext _dbContext;
        private readonly IMapper _mapper;
        public CategoriesService(MilkCoffeeContext milkCoffeeContext, IMapper mapper)
        {
            _dbContext = milkCoffeeContext;
            _mapper = mapper;
        }
        public async Task<APIResponse<CategoryResponse>> CreateCategory(CategoryRequest request)
        {
            APIResponse<CategoryResponse> response = new();

            var id = Guid.NewGuid();
            Category cate = new Category();
            {
                cate.CategoryId = id;
                cate.CategoryName = request.CategoryName;
            };
            await _dbContext.Categories.AddAsync(cate);
            await _dbContext.SaveChangesAsync();
            var map = _mapper.Map<CategoryResponse>(cate);
            response.ToSuccessResponse("Create success category", statuscode: 200);
            response.Data = map;
            return response;
        }

        public async Task<APIResponse<IEnumerable<CategoryResponse>>> GetCategoriesAsync()
        {
            APIResponse<IEnumerable<CategoryResponse>> response = new();

            var category = await _dbContext.Categories.ToListAsync();
            if (category == null)
            {
                response.ToFailedResponse("Not found", statuscode: 404);
            }
            IEnumerable<CategoryResponse> result = category.Select(
                c =>
                {
                    return new CategoryResponse()
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                    };
                }).ToList();
            response.Data = result;
            response.ToSuccessResponse("Get success category", statuscode: 200);
            return response;
        }

        public async Task<APIResponse<CategoryResponse>> UpdateCategory(Guid? id, CategoryRequest request)
        {
            APIResponse<CategoryResponse> response = new();
            var cate = await _dbContext.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
            if (cate == null)
            {
                response.ToFailedResponse("Not Found CategoryId", statuscode: 404);
            }
            cate.CategoryName = request.CategoryName;
            _dbContext.Categories.Update(cate);
            await _dbContext.SaveChangesAsync();
            var map = _mapper.Map<CategoryResponse>(cate);
            response.ToSuccessResponse("Update success category", statuscode: 200);
            response.Data = map;
            return response;
        }
    }
}
