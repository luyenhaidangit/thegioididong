using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Extensions
{
    public static class CategoryExtension
    {
        public static IQueryable<Category> GetAll(this IQueryable<Category> query)
        {
            query = query.Include(x => x.Slugs).Select(category => new Category
            {
                Id = category.Id,
                Name = category.Name,

                Slug = category.Slugs.FirstOrDefault(x => x.ReferenceId == category.Id && x.ReferenceType == Constants.Common.Slug.CategoryReferenceType)
            }); ;

            return query;
        }
    }
}
