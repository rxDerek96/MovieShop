﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;

        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<int> GetCount(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).CountAsync();
        }

        public virtual async Task<bool> GetExists(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }

        public virtual async Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
