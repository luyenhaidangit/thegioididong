using Microsoft.AspNetCore.Mvc;
using Thegioididong.Api.Constants.Responses;
using Thegioididong.Api.Models.Media;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Services;

namespace Thegioididong.Api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly MediaService _mediaService;

        public MediaController(MediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet("get-list")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetMediaRequest request)
        {
            var data = await _mediaService.GetListAsync(request);

            var result = new ApiResult<GetMediaResult>()
            {
                Status = true,
                Message = NoticeConstant.GetSuccessMessage,
                Data = data
            };

            return Ok(result);
        }

        [HttpPost("create-media-file")]
        public async Task<IActionResult> CreateMediaFileAsync([FromForm] CreateMediaFileRequest request)
        {
            var data = await _mediaService.CreateMediaFileAsync(request);

            var result = new ApiResult<string>()
            {
                Status = true,
                Message = NoticeConstant.CreateSuccessMessage,
                Data = data
            };

            return Ok(result);
        }
    }
}
