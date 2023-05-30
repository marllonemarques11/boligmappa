using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.BusinessRules.Contracts;

namespace DT.BusinessRules.Rules
{
    public class BaseRules<TEntity>: IBaseRules<TEntity>
    where TEntity: class
    {
        
    }
}