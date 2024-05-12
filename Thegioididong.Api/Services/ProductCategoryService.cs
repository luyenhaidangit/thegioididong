using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Exceptions.Common;
using Thegioididong.Api.Helpers;
using Thegioididong.Api.Models.Ecommerce.ProductCategory;
using Thegioididong.Api.Models.Requests;

namespace Thegioididong.Api.Services
{
    public class ProductCategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;   

        public ProductCategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Core
        #endregion

        #region Admin
        // CRUD
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

        public async Task<ProductCategory> CreateAsync(CreateProductCategoryRequest request)
        {
            var existParentCategory = await _dbContext.ProductCategories.AnyAsync(x => x.Id == request.ParentId);

            if (!existParentCategory)
            {
                throw new BadRequestException("The specified parent category ID does not exist.");
            }

            var category = _mapper.Map<ProductCategory>(request);

            await _dbContext.ProductCategories.AddAsync(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<ProductCategory> EditAsync(EditProductCategoryRequest request)
        {
            var category = await _dbContext.ProductCategories.FindAsync(request.Id);

            if (category is null)
            {
                throw new BadRequestException("The category ID does not exist.");
            }

            category = _mapper.Map<ProductCategory>(request);

            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<ProductCategory> DeleteAsync(EntityIdentityRequest<int> request)
        {
            var category = await _dbContext.ProductCategories.FindAsync(request.Id);

            if (category is null)
            {
                throw new BadRequestException("The category ID does not exist.");
            }

            _dbContext.ProductCategories.Remove(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<bool> CheckExistByPropertiesAsync(CheckExistByPropertiesRequest request)
        {
            var exist = false;

            if (request.PropertyName == "id")
            {
                exist = await _dbContext.ProductCategories.AnyAsync(x => x.Id == int.Parse(request.Value));
            }

            if (request.PropertyName == "slug")
            {
                exist = await _dbContext.ProductCategories.AnyAsync(x => x.Slug == request.Value);
            }

            return exist;
        }
        #endregion
    }
}
