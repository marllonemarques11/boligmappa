using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.Infra.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DT.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}