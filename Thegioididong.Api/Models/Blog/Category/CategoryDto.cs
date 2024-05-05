using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Models.Blog.Category
{
    public class CategoryDto
    {
        public string Name { get; set; }

        public long ParentId { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; }

        public int AuthorId { get; set; }

        public string AuthorType { get; set; }

        public string? Icon { get; set; }

        public int Order { get; set; }

        public int IsFeatured { get; set; }

        public int IsDefault { get; set; }

        public Slug? Slug { get; set; }
    }
}
