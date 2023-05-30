using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;

namespace DT.BusinessRules.Contracts
{
    public interface IBaseRules<TEntity>
    where TEntity : class
    {
        
    }
}