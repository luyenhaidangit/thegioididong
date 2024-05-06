using AutoMapper;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Models.Blog.Category;
using Thegioididong.Api.Models.Responses;

namespace Thegioididong.Api.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryFilterDto>()
            .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slugs.FirstOrDefault(x => x.ReferenceType == Constants.Common.Slug.CategoryReferenceType).Key ?? null));

            CreateMap<Category, CategoryListDto>()
            .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slugs.FirstOrDefault(x => x.ReferenceType == Constants.Common.Slug.CategoryReferenceType).Key ?? null))
            .ForMember(dest => dest.Childrens, opt => opt.MapFrom(src => src.Childrens))
            .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent));

            CreateMap<PagingResult<Category>, PagingResult<CategoryListDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
