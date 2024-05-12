using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Models.Blog.Category;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Thegioididong.Api.Controllers.Guest
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(CategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        //[HttpGet("")]
        //public async Task<IActionResult> GetCategoriesPagingAsync([FromQuery] GetCategoryRequest request)
        //{
        //    var data = await _categoryService.GetCategoriesPagingAsync(request);

        //    var dataConvert = _mapper.Map<PagingResult<CategoryListDto>>(data);

        //    var result = new ApiResult<PagingResult<CategoryListDto>>()
        //    {
        //        Status = true,
        //        Message = "Danh sách danh mục đã được lấy thành công!",
        //        Data = dataConvert
        //    };

        //    return Ok(result);
        //}

        //[HttpGet("filters")]
        //public async Task<IActionResult> GetCategoriesFilterAsync([FromQuery] GetCategoryRequest request)
        //{
        //    // Reset request
        //    request.PageIndex = 1;

        //    // Bussiness
        //    var pagingResult = await _categoryService.GetCategoriesPagingAsync(request);

        //    var items = pagingResult.Items;

        //    var itemsConvert = _mapper.Map<List<CategoryFilterDto>>(items);

        //    var result = new ApiResult<List<CategoryFilterDto>>()
        //    {
        //        Status = true,
        //        Message = "Danh sách danh mục đã được lấy thành công!",
        //        Data = itemsConvert
        //    };

        //    return Ok(result);
        //}

        //[HttpGet("{slug}")]
        //public async Task<IActionResult> FindBySlug([FromRoute] string slug)
        //{
        //    var data = await _categoryService.FindBySlug(slug);

        //    var dataConvert = _mapper.Map<CategoryListDto>(data);

        //    var result = new ApiResult<CategoryListDto>()
        //    {
        //        Status = true,
        //        Message = "Lấy danh mục thành công!",
        //        Data = dataConvert
        //    };

        //    return Ok(result);
        //}
    }
}
