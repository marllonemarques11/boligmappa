using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;

namespace DT.BusinessRules.Contracts
{
    public interface IUserRules: IBaseRules<User>
    {
        Task<Dictionary<string, IEnumerable<string>>> GetUsersTodos();
        Task<Dictionary<string, IEnumerable<string>>> GetUsersPosts();
    }
}