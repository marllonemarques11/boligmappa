using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Infra.ExternalServices.DummyService.Models;

namespace DT.Infra.ExternalServices.DummyService.Contracts
{
    public interface IDummyService
    {
        Task<UserModel> GetUsersAsync();
        Task<PostModel> GetPostsAsync();
        Task<TodoModel> GetTodosAsync();
        Task SaveUsersAsync(UserModel userModel, PostModel postModel, TodoModel todoModel);
        Task<bool> CheckIfUserExists();
    }
}