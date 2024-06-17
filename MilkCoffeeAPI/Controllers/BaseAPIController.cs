using Microsoft.AspNetCore.Mvc;
using MilkCoffeeAPI.Core;

namespace MilkCoffeeAPI.Controllers
{
    [Route("api/v1.0/[controller]s")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        protected IActionResult sendResponse<T>(T response) where T : APIResponse
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        protected IActionResult SendResponse<T>(APIResponse<T> response) where T : class
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        protected IActionResult SendResponse(ApiResponseListError response)
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
