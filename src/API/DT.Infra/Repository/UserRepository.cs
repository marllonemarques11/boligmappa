using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.Infra.Contracts;
using DT.Domain.Enums;

namespace DT.Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _dbContext)
        : base(_dbContext)
        {

        }

        public async Task<IEnumerable<User>> GetUsersByPostCount()
        {
            try
            {
                return await Task.FromResult(_dbContext.Users.Where(p => p.userPosts > 2));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetUsersByCardType()
        {
            try
            {
                return await Task.FromResult(_dbContext.Users.Where(p => p.cardType == CardType.mastercard.ToString()));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}