using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using DT.DummyClient.Models;

namespace DT.DummyClient
{
    public class Program
    {
        public static async Task Main()
        {
            var results = await GetPostsAsync();

            Console.WriteLine("Showing posts ...");
            
            foreach (var result in results)
            {
                Console.WriteLine(result.userName);


                if (result.posts.Count() > 0)
                {
                    foreach (var post in result.posts)
                    {
                        Console.WriteLine(post);
                        Console.WriteLine("--");
                    }
                }
                else{
                    Console.WriteLine("This user has no posts.");
                }
                Console.WriteLine("______________________________________________________________________________________________________________________");
            }
        }

        public static async Task<List<PostModel>> GetPostsAsync()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5229/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("GetUsersPosts");
            List<PostModel> models = new List<PostModel>();

            if (response.IsSuccessStatusCode)
            {
                var postData = await response.Content.ReadAsStringAsync();
                models = JsonConvert.DeserializeObject<List<PostModel>>(postData);
            }

            return await Task.FromResult(models);
        }
    }
}