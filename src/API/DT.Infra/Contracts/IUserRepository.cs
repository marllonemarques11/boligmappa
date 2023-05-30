using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;

namespace DT.Infra.Contracts
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task <IEnumerable<User>> GetUsersByPostCount(int postsCount);
        Task <IEnumerable<User>> GetUsersByCardType(string cardType);
    }
}