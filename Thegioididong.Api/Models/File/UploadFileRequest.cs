namespace Thegioididong.Api.Models.File
{
    public class UploadFileRequest
    {
        public IFormFile? File { get; set; }

        public string? Folder {  get; set; }
    }
}
