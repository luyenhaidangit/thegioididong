using Thegioididong.Api.Contracts.Data.Repositories;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore;

namespace Thegioididong.Api.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category, long, ApplicationDbContext>
    {
    }
}
