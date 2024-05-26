using AutoMapper;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Models.Media;

namespace Thegioididong.Api.Mappers
{
    public class MediaMapper : Profile
    {
        public MediaMapper()
        {
            CreateMap<MediaFile, MediaFileDto>();

            CreateMap<MediaFolder, MediaFolderDto>();
        }
    }
}
