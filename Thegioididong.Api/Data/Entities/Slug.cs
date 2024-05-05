using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class Slug : EntityAuditBase<long>
    {
        public string Key { get; set; }

        public long ReferenceId { get; set; }

        public string ReferenceType { get; set; }

        public string? Prefix { get; set; }
    }
}
