using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Enums.Common;
using Thegioididong.Api.Infrastructures.Extensions;
using Thegioididong.Api.Models.Blog.Category;
using System.Linq.Dynamic.Core;
using System.Reflection;
using Thegioididong.Api.Models.Responses;
using System.Globalization;

namespace Thegioididong.Api.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext dbContext,IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Core
        #endregion

        #region Bussiness
        public async Task<PagingResult<Category>> GetCategoriesPagingAsync(GetCategoryRequest request)
        {
            var query = _dbContext.Categories
            .Include(x => x.Slugs)
            .Where(x => x.Status == BaseStatusEnum.Published.ToEnumMember())
            .AsQueryable();

            int total = await query.CountAsync();

            string orderString = request.OrderBy + " " + request.SortBy;

            var items = await query
            .OrderBy(orderString)
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

            var result = new PagingResult<Category>(items, request.PageIndex, request.PageSize, request.SortBy, request.OrderBy, total);

            return result;
        }
        #endregion
    }
}
