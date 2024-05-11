namespace Thegioididong.Api.Models.Ecommerce.ProductCategory
{
    public class EditProductCategoryRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }

        public int Order { get; set; }

        public string Slug { get; set; }

        public string? Image { get; set; }

        public bool IsFeatured { get; set; }

        public string? Icon { get; set; }

        public string? IconImage { get; set; }
    }
}
