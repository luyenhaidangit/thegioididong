namespace Thegioididong.Api.Models.Blog.Category
{
    public class CategoryWithParent
    {
        public Data.Entities.Category Category { get; set; }

        public Data.Entities.Category? Parent { get; set; }
    }
}
