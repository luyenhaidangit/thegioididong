using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Api.Models.Blog.Category;
using Thegioididong.Api.Models.Ecommerce.ProductCategory;
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
        private readonly IMapper _mapper;

        public ProductCategoryController(ProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet("product-categories-tree")]
        public async Task<IActionResult> GetProductCategoiesTreeAsync()
        {
            var data = await _productCategoryService.GetProductCategoiesTreeAsync();

            var dataConvert = _mapper.Map<List<ProductCategoryTree>>(data);

            var result = new ApiResult<List<ProductCategoryTree>>()
            {
                Status = true,
                Message = "Danh sách danh mục đã được lấy thành công!",
                Data = dataConvert
            };

            return Ok(result);
        }
    }
}
