using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkCoffeeAPI.Core;
using MilkCoffeeAPI.Entities;
using MilkCoffeeAPI.Models.Response;
using MilkCoffeeAPI.Models.Resquest;
using System.Collections.Generic;

namespace MilkCoffeeAPI.Services.ProductsService
{
    public class ProductService : IProductsService
    {
        private MilkCoffeeContext _dbContext;
        private readonly IMapper _mapper;
        public ProductService(MilkCoffeeContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<APIResponse<ProductResponse>> CreateProduct(ProductRequest request)
        {
            APIResponse<ProductResponse> response = new();

            var id = Guid.NewGuid();

            Product product = new Product()
            {
                ProductId = id,
                ProductName = request.ProductName,
                ProductPrice = request.Price,
                Description = request.ProductDescription,
                CategoryId = request.CategoryId,
                ImageId = request.ImageId ?? null,
            };
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            var map = _mapper.Map<ProductResponse>(product);
            response.ToSuccessResponse("Create success product", statuscode: 200);
            response.Data = map;
            return response;

        }

        public async Task<APIResponse<IEnumerable<ProductResponse>>> GetProductByCategoryId(Guid? categoryId)
        {
            APIResponse<IEnumerable<ProductResponse>> response = new();
            var cate = await _dbContext.Categories.SingleOrDefaultAsync(c => c.CategoryId == categoryId);
            if (cate == null)
            {
                response.ToFailedResponse("Not Found CategoryId", statuscode: 404);
            }
            var product = await _dbContext.Products.ToListAsync();

            IEnumerable<ProductResponse> result = product.Select(
                p =>
                {
                    return new ProductResponse()
                    {
                        CategoryId = p.CategoryId,
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        ProductDescription = p.Description,
                        Image = p.ImageId,
                        CategoryName = cate.CategoryName,
                    };
                }).ToList();
            response.Data = result;
            response.ToSuccessResponse("Get list product success", statuscode: 200);
            return response;
        }

        public async Task<APIResponse<ProductResponse>> UpdateProduct(Guid? productId, ProductRequest request)
        {
            APIResponse<ProductResponse> response = new();
            var checkProduct = await _dbContext.Products.SingleOrDefaultAsync(p => p.ProductId == productId);
            if (checkProduct == null)
            {
                response.ToFailedResponse("Not Found Product", statuscode: 404);
            }
            Product product = new Product();
            product.ProductPrice = request.Price ?? product.ProductPrice;
            product.ProductName = request.ProductName ?? product.ProductName;
            product.CategoryId = request.CategoryId ?? product.CategoryId;
            product.Description = request.ProductDescription ?? product.Description;

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            var map = _mapper.Map<ProductResponse>(product);
            response.ToSuccessResponse("Update product Success", statuscode: 200);
            response.Data = map;
            return response;

        }
    }
}
