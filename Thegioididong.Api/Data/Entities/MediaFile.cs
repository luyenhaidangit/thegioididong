using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.Entities
{
    public class MediaFile : EntityAuditBase<int>
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string? AltText { get; set; }

        public int FolderId { get; set; }

        public string MimeType { get; set; }

        public int Size { get; set; }

        public string URL { get; set; }

        public string? Options { get; set; }
    }
}