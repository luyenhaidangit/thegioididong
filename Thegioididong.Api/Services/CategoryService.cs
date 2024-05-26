using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Enums.Common;
using Thegioididong.Api.Infrastructures.Extensions;
using Thegioididong.Api.Models.Blog.Category;
using System.Linq.Dynamic.Core;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Exceptions.Common;

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
        public async Task<List<Category>> GetAll()
        {
            var categories = await _dbContext.Categories
                .Include(x => x.Slugs)
                .Include(x => x.Childrens)
                .Where(x => x.Status == BaseStatusEnum.Published.ToEnumMember())
                .ToListAsync();

            foreach (var category in categories)
            {
                category.Parent = category.ParentId != 0 ? categories.FirstOrDefault(x => x.Id == category.ParentId) : null;
            }

            return categories; 
        }
        #endregion

        #region Bussiness
        /// <summary>
        /// Get category with paging
        /// </summary>
        public async Task<PagingResult<Category>> GetCategoriesPagingAsync(GetCategoryRequest request)
        {
            var categories = await this.GetAll();

            int total = categories.Count();

            if (request.PageIndex == null || request.PageIndex < 1) request.PageIndex = 1;
            if (request.PageSize == null || request.PageSize < 1) request.PageSize = total;

            string orderString = request.OrderBy + " " + request.SortBy;

            var items = categories
                .AsQueryable()
                .OrderBy(orderString)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var result = new PagingResult<Category>(items, request.PageIndex, request.PageSize, request.SortBy, request.OrderBy, total);

            return result;
        }

        /// <summary>
        /// Find by slug
        /// </summary>
        public async Task<Category> FindBySlug(string slug)
        {
            var slugObj = await _dbContext.Slugs.FirstOrDefaultAsync(s => s.Key == slug && s.ReferenceType == Constants.Common.Slug.CategoryReferenceType);

            if (slugObj == null)
            {
                throw new NotFoundException("Slug thể loại không tồn tại trong hệ thống!");
            };

            var category = await _dbContext.Categories
                .Include(x => x.Slugs)
                .Include(x => x.Childrens)
                .Where(x => x.Status == BaseStatusEnum.Published.ToEnumMember())
                .FirstOrDefaultAsync(s => s.Id == slugObj.ReferenceId);

            if(category == null)
            {
                throw new NotFoundException("Thể loại không tồn tại trong hệ thống!");
            };

            return category;
        }
        #endregion
    }
}
