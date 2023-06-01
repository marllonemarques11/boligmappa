using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT.Infra.ExternalServices.DummyService.Contracts;
using DT.Infra.ExternalServices.DummyService.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace DT.Infra.ExternalServices.DummyService.Services
{
    public class DummyService: IDummyService
    {
        HttpClient client = new HttpClient();

        public DummyService()
        {
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
    }
}