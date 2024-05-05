using AutoMapper;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Models.Blog.Category;

namespace Thegioididong.Api.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, Category>()
            .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slugs.FirstOrDefault(x => x.ReferenceType == Constants.Common.Slug.CategoryReferenceType)));

            CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slugs.FirstOrDefault(x => x.ReferenceType == Constants.Common.Slug.CategoryReferenceType)));
        }
    }
}
