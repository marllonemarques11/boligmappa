using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Domain.Entities;
using DT.Infra.ExternalServices.DummyService.Contracts;
using DT.Infra.ExternalServices.DummyService.Models;
using DT.Infra.ExternalServices.DummyService.Utils;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace DT.Infra.ExternalServices.DummyService.Services
{
    public class DummyService: IDummyService
    {
        private IUserDummyData _userDummyData;
        HttpClient client = new HttpClient();

        public DummyService(IUserDummyData userDummyData)
        {
            _userDummyData = userDummyData;
            client.BaseAddress = new Uri("https://dummyjson.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserModel> GetUsersAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Users");
            UserModel userModel = new UserModel();
            
            if (response.IsSuccessStatusCode)
            {
                var userData = await response.Content.ReadAsStringAsync();
                userModel = JsonConvert.DeserializeObject<UserModel>(userData);
            }

            return await Task.FromResult(userModel);
        }

        public async Task<PostModel> GetPostsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Posts");
            PostModel postModel = new PostModel();
            
            if (response.IsSuccessStatusCode)
            {
                var postData = await response.Content.ReadAsStringAsync();
                postModel = JsonConvert.DeserializeObject<PostModel>(postData);
            }

            return await Task.FromResult(postModel);
        }

        public async Task<TodoModel> GetTodosAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Todos");
            TodoModel todoModel = new TodoModel();
            
            if (response.IsSuccessStatusCode)
            {
                var todoData = await response.Content.ReadAsStringAsync();
                todoModel = JsonConvert.DeserializeObject<TodoModel>(todoData);
            }

            return await Task.FromResult(todoModel);
        }

        public async Task SaveUsersAsync(UserModel userModel, PostModel postModel, TodoModel todoModel){
            try
            {
                Converter c = new Converter();
                List<User> users = c.UserModelToEntity(userModel.desc, postModel.desc, todoModel.desc);
                List<Post> posts = c.PostModelToEntity(userModel.desc, postModel.desc, todoModel.desc);
                List<Todo> todos = c.TodoModelToEntity(todoModel.desc);

                foreach (var user in users)
                {
                    user.Posts = posts.Where(p => p.userId == user.id).ToList();
                    user.Todos = todos.Where(p => p.userId == user.id).ToList();
                }

                await _userDummyData.CreateRangeAsync(users);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}