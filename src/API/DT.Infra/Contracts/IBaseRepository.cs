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
        Task CreateAsync(TEntity entity);
    }
}