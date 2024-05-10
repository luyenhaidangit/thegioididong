using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Enums.Common;
using Thegioididong.Api.Models.Blog.Category;
using Thegioididong.Api.Models.Responses;

namespace Thegioididong.Api.Services
{
    public class ProductCategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }

        #region Core
        public async Task<List<ProductCategory>> GetAll()
        {
            var categories = await _dbContext.ProductCategories
                .ToListAsync();

            return categories;
        }
        #endregion

        //public async Task<PagingResult<Category>> GetCategoriesPagingAsync(GetCategoryRequest request)
        //{
        //    var categories = await this.GetAll();

        //    int total = categories.Count();

        //    if (request.PageIndex == null || request.PageIndex < 1) request.PageIndex = 1;
        //    if (request.PageSize == null || request.PageSize < 1) request.PageSize = total;

        //    string orderString = request.OrderBy + " " + request.SortBy;

        //    var items = categories
        //        .AsQueryable()
        //        .OrderBy(orderString)
        //        .Skip((request.PageIndex - 1) * request.PageSize)
        //        .Take(request.PageSize)
        //        .ToList();

        //    var result = new PagingResult<Category>(items, request.PageIndex, request.PageSize, request.SortBy, request.OrderBy, total);

        //    return result;
        //}
    }
}
