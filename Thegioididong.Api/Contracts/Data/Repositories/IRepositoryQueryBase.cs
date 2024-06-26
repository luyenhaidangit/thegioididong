﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Contracts.Data.Repositories
{
    public interface IRepositoryQueryBase<T, in K> where T : EntityBase<K>
    {
        IQueryable<T> FindAll(bool trackChanges = false);
        IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false,
            params Expression<Func<T, object>>[] includeProperties);

        Task<T?> GetByIdAsync(K id);
        Task<T?> GetByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties);
    }

    public interface IRepositoryQueryBase<T, K, TContext> : IRepositoryQueryBase<T, K> where T : EntityBase<K> where TContext : DbContext
    {
    }
}
