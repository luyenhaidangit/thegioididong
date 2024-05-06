namespace Thegioididong.Api.Models.Blog.Category
{
    public class CategoryListDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string? Description { get; set; }

        public List<CategoryFilterDto>? Childrens { get; set; }

        public CategoryFilterDto? Parent { get; set; }
    }
}
