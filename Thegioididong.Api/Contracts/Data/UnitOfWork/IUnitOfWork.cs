using Microsoft.EntityFrameworkCore;

namespace Thegioididong.Api.Contracts.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
    }
}
