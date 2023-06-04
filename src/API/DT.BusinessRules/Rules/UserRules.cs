using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.BusinessRules.Contracts;
using DT.Infra.Contracts;

namespace DT.BusinessRules.Rules
{
    public class UserRules : BaseRules<User>, IUserRules
    {
        private IUserRepository _userRepository;

        public UserRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //DRY Refactoting needed.
        public async Task<Dictionary<string, IEnumerable<string>>> GetUsersTodos()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetUsersByPostCount();

                var todos = (from user in users.ToList()
                             select new
                             {
                                key = user.userName,
                                value = user.Todos.Select(p => p.todo)
                             }).ToDictionary(p => p.key, p => p.value);

                return await Task.FromResult(todos);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Dictionary<string, IEnumerable<string>>> GetUsersPosts()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetUsersByCardType();

                var posts = (from user in users.ToList()
                             select new{
                                key = user.userName,
                                value = user.Posts.Select(p => p.body)
                             }).ToDictionary(p => p.key, p => p.value);

                return await Task.FromResult(posts);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}