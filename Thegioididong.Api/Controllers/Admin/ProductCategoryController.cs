using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Api.Constants.Responses;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Models.Ecommerce.ProductCategory;
using Thegioididong.Api.Models.Requests;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Services;

namespace Thegioididong.Api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
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
                Message = NoticeConstant.GetSuccessMessage,
                Data = dataConvert
            };

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCategoryRequest request)
        {
            var data = await _productCategoryService.CreateAsync(request);

            var result = new ApiResult<ProductCategory>()
            {
                Status = true,
                Message = NoticeConstant.CreateSuccessMessage,
                Data = data
            };

            return Ok(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditAsync([FromBody] EditProductCategoryRequest request)
        {
            var data = await _productCategoryService.EditAsync(request);

            var result = new ApiResult<ProductCategory>()
            {
                Status = true,
                Message = NoticeConstant.EditSuccessMessage,
                Data = data
            };

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] EntityIdentityRequest<int> request)
        {
            var data = await _productCategoryService.DeleteAsync(request);

            var result = new ApiResult<ProductCategory>()
            {
                Status = true,
                Message = NoticeConstant.DeleteSuccessMessage,
                Data = data
            };

            return Ok(result);
        }
    }
}
