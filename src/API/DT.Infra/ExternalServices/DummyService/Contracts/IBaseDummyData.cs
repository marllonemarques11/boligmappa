using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;

namespace DT.Infra.ExternalServices.DummyService.Contracts
{
    public interface IBaseDummyData<TEntity>
    where TEntity : class
    {
        Task CreateRangeAsync(List<TEntity> entities);
    }
}