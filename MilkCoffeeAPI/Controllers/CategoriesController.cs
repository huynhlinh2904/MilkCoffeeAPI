using Microsoft.AspNetCore.Mvc;
using MilkCoffeeAPI.Models.Resquest;
using MilkCoffeeAPI.Services.CategoriesService;

namespace MilkCoffeeAPI.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoriesController : BaseAPIController
    {
        private readonly ICategoriesService _categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest request)
        {
            try
            {
                var result = await _categoryService.CreateCategory(request);
                if (result.Success == false)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var result = await _categoryService.GetCategoriesAsync();
                if (result.Success == false)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Guid? id, CategoryRequest request)
        {
            try
            {
                var result = await _categoryService.UpdateCategory(id, request);
                if (result.Success == false)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
