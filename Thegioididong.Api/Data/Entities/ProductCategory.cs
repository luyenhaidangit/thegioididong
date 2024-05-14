using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class ProductCategory : EntityAuditBase<int>
    {
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

        #region Relationship
        public virtual List<ProductCategory> Childrens { get; set; }

        public virtual List<Product> Products { get; set; }
        #endregion
    }
}
