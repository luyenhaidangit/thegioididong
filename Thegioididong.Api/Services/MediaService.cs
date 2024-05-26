using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Exceptions.Common;
using Thegioididong.Api.Models.File;
using Thegioididong.Api.Models.Media;

namespace Thegioididong.Api.Services
{
    public class MediaService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly FileService _fileService;
        private readonly IMapper _mapper;

        public MediaService(ApplicationDbContext dbContext,FileService fileService, IMapper mapper)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<GetMediaResult> GetListAsync(GetMediaRequest request)
        {
            var folders = new List<MediaFolder>();
            var files = new List<MediaFile>();

            if (!request.FolderId.HasValue)
            {
                folders = await _dbContext.MediaFolders.Where(x => x.ParentId == null).ToListAsync();
                files = await _dbContext.MediaFiles.Where(x => x.FolderId == null).ToListAsync();
            }
            else
            {
                folders = await _dbContext.MediaFolders.Where(x => x.ParentId == request.FolderId).ToListAsync();
                files = await _dbContext.MediaFiles.Where(x => x.FolderId == request.FolderId).ToListAsync();
            }

            var filesMapper = _mapper.Map<List<MediaFileDto>>(files);
            var foldersMapper = _mapper.Map<List<MediaFolderDto>>(folders);

            var result = new GetMediaResult()
            {
                MediaFolders = foldersMapper,
                MediaFiles = filesMapper,
            };

            return result;
        }

        public async Task<string> CreateMediaFileAsync(CreateMediaFileRequest request)
        {
            var folder = await _dbContext.MediaFolders.FindAsync(request.FolderId);

            if (folder is null)
            {
                throw new BadRequestException("Media folder không tồn tại trong hệ thống!");
            };

            var folderWithParents = await GetFolderWithParents(folder);

            var folderUrl = BuildFolderUrlPath(folderWithParents);

            var uploadFileRequest = new UploadFileRequest()
            {
                File = request.File,
                Folder = folderUrl
            };

            var existFile = await _dbContext.MediaFiles.AnyAsync(x => x.URL == folderUrl + "/" + request.File.FileName);

            if (existFile)
            {
                throw new BadRequestException("Folder đã tồn tại file cùng tên!");
            }

            var url = await _fileService.UploadFileAsync(uploadFileRequest);

            var fileMedia = new MediaFile()
            {
                UserId = 1,
                Name = Path.GetFileNameWithoutExtension(url),
                AltText = Path.GetFileNameWithoutExtension(url),
                FolderId = request.FolderId,
                MimeType = "",
                Size = 1,
                URL = url,
                Options = "[]"
            };

            await _dbContext.MediaFiles.AddAsync(fileMedia);

            await _dbContext.SaveChangesAsync();

            return url;
        }

        private async Task<MediaFolder> GetFolderWithParents(MediaFolder folder)
        {
            if (folder.ParentId.HasValue)
            {
                folder.ParentFolder = await _dbContext.MediaFolders.FindAsync(folder.ParentId.Value);

                if (folder.ParentFolder != null)
                {
                    await GetFolderWithParents(folder.ParentFolder);
                }
            }
            return folder;
        }

        private string BuildFolderUrlPath(MediaFolder folder)
        {
            var urlSegments = new List<string>();
            while (folder != null)
            {
                urlSegments.Insert(0, folder.Name);
                folder = folder.ParentFolder;
            }
            return string.Join("/", urlSegments);
        }
    }
}
