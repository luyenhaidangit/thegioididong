using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Attributes;
using Thegioididong.Api.Contracts.Data.UnitOfWork;

namespace Thegioididong.Api.Infrastructures.Data.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();

        public Task<int> CommitAsync() => _context.SaveChangesAsync();
    }
}
