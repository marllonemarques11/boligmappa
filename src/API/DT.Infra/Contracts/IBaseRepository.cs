using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;

namespace DT.Infra.Contracts
{
    public interface IBaseRepository<TEntity>
    where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        // Task<IEnumerable<TEntity>> GetByIdRange(List<int> ids);
        Task CreateRangeAsync(List<TEntity> entities);
    }
}