using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Models.Blog.Category;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Services;
using Thegioididong.Api.Services.Interfaces;

namespace Thegioididong.Api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly ICategoryService _categoryService;

        //public CategoryController(ICategoryService categoryService) 
        //{
        //    _categoryService = categoryService;
        //}

        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategoriesPagingAsync([FromQuery] GetCategoryRequest request)
        {
            var data = await _categoryService.GetCategoriesPagingAsync(request);

            var result = new ApiResult<PagingResult<Category>>()
            {
                Status = true,
                Message = "Danh sách banner đã được lấy thành công!",
                Data = data
            };

            return Ok(result);
        }
    }
}
