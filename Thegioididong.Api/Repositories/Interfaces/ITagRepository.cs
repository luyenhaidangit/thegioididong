using Thegioididong.Api.Contracts.Data.Repositories;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;

namespace Thegioididong.Api.Repositories.Interfaces
{
    public interface ITagRepository : IRepositoryBase<Tag, long, ApplicationDbContext>
    {
    }
}
