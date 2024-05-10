using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class Category : EntityAuditBase<long>
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

        #region Relationship
        public virtual IEnumerable<Post> Posts { get; set; }

        public virtual IEnumerable<Slug> Slugs { get; set; }

        [NotMapped]
        public virtual Slug? Slug { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category? Parent { get; set; }

        public virtual List<Category>? Childrens { get; set; }
        #endregion
    }
}
