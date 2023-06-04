using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.Infra.ExternalServices.DummyService.Contracts;
using DT.Infra.Repository;

namespace DT.Infra.ExternalServices.DummyService.Data
{
    public class UserDummyData: BaseDummyData<User>, IUserDummyData
    {
        public UserDummyData(AppDbContext _dbContext)
        : base(_dbContext)
        {
            
        }
    }
}