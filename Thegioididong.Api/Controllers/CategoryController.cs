using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Thegioididong.Api.Services.Interfaces;

namespace Thegioididong.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _categoryService.GetProductsAsync();

            return Ok(result);
        }
    }
}
