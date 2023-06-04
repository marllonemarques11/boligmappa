using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.Infra.ExternalServices.DummyService.Contracts;
using DT.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace DT.Infra.ExternalServices.DummyService.Data
{
    public class BaseDummyData<TEntity> : IBaseDummyData<TEntity>
    where TEntity : class
    {
        public readonly AppDbContext _dbContext;

        public BaseDummyData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateRangeAsync(List<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}