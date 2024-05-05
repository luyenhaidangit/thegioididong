using Thegioididong.Api.Attributes;
using Thegioididong.Api.Contracts.Data.UnitOfWork;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Infrastructures.Data.Repositories;
using Thegioididong.Api.Repositories.Interfaces;

namespace Thegioididong.Api.Repositories
{
    [ScopedRegistration]
    public class TagRepository : RepositoryBase<Tag, long, ApplicationDbContext>, ITagRepository
    {
        public TagRepository(ApplicationDbContext dbContext, IUnitOfWork<ApplicationDbContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }
    }
}
