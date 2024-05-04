using Thegioididong.Api.Attributes;
using Thegioididong.Api.Repositories.Interfaces;
using Thegioididong.Api.Services.Interfaces;

namespace Thegioididong.Api.Services
{
    [ScopedRegistration]
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
    }
}
