using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class Tag : EntityAuditBase<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public string AuthorType { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; }
    }
}
