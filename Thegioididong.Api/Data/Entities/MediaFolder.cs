using System.ComponentModel.DataAnnotations.Schema;
using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class MediaFolder : EntityAuditBase<int>
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string? Color { get; set; }

        public string Slug { get; set; }

        public int? ParentId { get; set; }

        #region Relationship
        [ForeignKey("ParentId")]
        public virtual MediaFolder? ParentFolder { get; set; }
        #endregion
    }
}