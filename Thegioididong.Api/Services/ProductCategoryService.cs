using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Models.Ecommerce.ProductCategory;

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
        #endregion

        #region Admin
        public async Task<List<ProductCategory>> GetProductCategoiesTreeAsync()
        {
            var categoriesWithChildren = await _dbContext.ProductCategories
            .Include(x => x.Products)
            .ToListAsync();

            var groupedCategories = categoriesWithChildren.ToLookup(cat => cat.ParentId);

            foreach (var category in categoriesWithChildren)
            {
                category.Childrens = groupedCategories[category.Id].ToList();
            }

            var rootCategories = categoriesWithChildren
                .Where(c => c.ParentId == null)
                .OrderBy(x => x.Order)
                .ThenByDescending(x => x.CreatedAt)
                .ToList();

            return rootCategories;
        }
        #endregion
    }
}
