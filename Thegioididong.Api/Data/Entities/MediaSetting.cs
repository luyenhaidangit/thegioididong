using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class MediaSetting : EntityAuditBase<int>
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public int? MediaId { get; set; }

        public int? UserId { get; set; }
    }
}