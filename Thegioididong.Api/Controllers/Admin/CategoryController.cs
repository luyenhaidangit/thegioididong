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
    }
}
