using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.Infra.Contracts;

namespace DT.Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _dbContext)
        : base(_dbContext)
        {

        }

        public async Task<IEnumerable<User>> GetUsersByPostCount(int postsCount)
        {
            try
            {
                return await Task.FromResult(_dbContext.Users.Where(p => p.userPosts == postsCount).ToList());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetUsersByCardType(string cardType)
        {
            try
            {
                return await Task.FromResult(_dbContext.Users.Where(p => p.cardType == cardType).ToList());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}