using Thegioididong.Api.Exceptions.Common;
using Thegioididong.Api.Helpers;
using Thegioididong.Api.Models.File;

namespace Thegioididong.Api.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFileAsync(UploadFileRequest request)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string relativeFolderPath = request.Folder;
            string uploadsFolder = Path.Combine(webRootPath, relativeFolderPath);

            if (!Directory.Exists(uploadsFolder))
            {
                //throw new BadRequestException("Folder không tổn tại trong hệ thống!");
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileExtension = Path.GetExtension(request.File.FileName);

            string uniqueFileName = Path.GetFileNameWithoutExtension(request.File.FileName) + TextHelper.GenerateTimeBased() + fileExtension;
            string filePath = Path.Combine(relativeFolderPath, uniqueFileName);

            using (var stream = new FileStream(Path.Combine(webRootPath, filePath), FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            string absoluteFilePath = Path.Combine(webRootPath, request.Folder, uniqueFileName);
            string relativeFilePath = Path.GetRelativePath(webRootPath, absoluteFilePath);

            return "/" + relativeFilePath.Replace("\\", "/");
        }

        public async Task<string> DeleteFileAsync(string fileUrl)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(webRootPath, fileUrl.TrimStart('/'));

            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
                return fileUrl;
            }
            else
            {
                return null;
            }
        }

        #region Methods to be implemented
        public Task<string> GetFileInfoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFilesInfoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> DownloadFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> DownloadFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> SearchFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> MoveFileAsync()
        {
            throw new NotImplementedException();
        }
        public Task<string> CopyFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> ShareFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> ShareFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> SetFilePermissionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFilePermissionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFileVersionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> RevertToFileVersionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> PreviewFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFileAuditTrailAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
