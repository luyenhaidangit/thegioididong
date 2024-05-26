namespace Thegioididong.Api.Models.Media
{
    public class CreateMediaFileRequest
    {
        public IFormFile? File { get; set; }

        public int? FolderId {  get; set; }
    }
}
