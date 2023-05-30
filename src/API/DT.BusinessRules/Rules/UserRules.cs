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
        public async Task<List<string>> GetUsersTodos()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetUsersByPostCount();

                var todos = (from user in users.ToList()
                             from todo in user.Todos
                             select todo);

                return await Task.FromResult(todos.ToList().Select(p => p.todo).ToList());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<string>> GetUsersPosts()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetUsersByCardType();

                var posts = (from user in users.ToList()
                             from post in user.Posts
                             select post);

                return await Task.FromResult(posts.ToList().Select(p => p.body).ToList());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}