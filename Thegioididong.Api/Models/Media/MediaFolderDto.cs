namespace Thegioididong.Api.Models.Media
{
    public class MediaFolderDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Basename { get; set; }

        public string Url { get; set; }

        public string FullUrl { get; set; }

        public string Type { get; set; }

        public string Icon { get; set; }

        public string Thumb { get; set; }

        public string Size { get; set; }

        public string MimeType { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string[] Options { get; set; }

        public int FolderId { get; set; }

        public string PreviewUrl { get; set; }

        public string PreviewType { get; set; }

        public string Alt { get; set; }
    }
}
