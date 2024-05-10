using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Api.Models.Blog.Category;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Services;
using Thegioididong.Api.Services.Interfaces;

namespace Thegioididong.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoryController(ProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategoriesPagingAsync([FromQuery] GetCategoryRequest request)
        {
            var result = await _productCategoryService.GetAll();

            return Ok(result);
        }
    }
}
