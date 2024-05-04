using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class Post : EntityAuditBase<long>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Content { get; set; }

        public string Status { get; set; }

        public int AuthorId { get; set; }

        public string AuthorType { get; set; }

        public bool IsFeatured { get; set; }

        public string? Image { get; set; }

        public uint Views { get; set; }

        public string? FormatType { get; set; }
    }
}
