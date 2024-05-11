using AutoMapper;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Models.Ecommerce.ProductCategory;

namespace Thegioididong.Api.Mappers
{
    public class ProductCategoryMapper : Profile
    {
        public ProductCategoryMapper()
        {
            //Get
            CreateMap<ProductCategory, ProductCategoryTree>()
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));

            //Create
            CreateMap<CreateProductCategoryRequest, ProductCategory>();

            //Edit
            CreateMap<EditProductCategoryRequest, ProductCategory>();
        }
    }
}
