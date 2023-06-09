using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DT.BusinessRules.Contracts;
using DT.EntryPoints.Models;

namespace DT.EntryPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRules _userRules;

        public UserController(IUserRules userRules)
        {
            _userRules = userRules;
        }

        [HttpGet]
        [Route("/GetUsersTodos")]
        public async Task<IActionResult> GetUsersTodos()
        {
            try
            {
                List<TodoModel> models = new List<TodoModel>();
                Dictionary<string, IEnumerable<string>> result = await _userRules.GetUsersTodos();

                foreach (var item in result)
                {
                    TodoModel model = new TodoModel();
                    model.userName = item.Key;
                    model.todos = item.Value;
                    models.Add(model);
                }
                return Ok(models);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("/GetUsersPosts")]
        public async Task<IActionResult> GetUsersPosts()
        {
            try
            {
                List<PostModel> models = new List<PostModel>();
                Dictionary<string, IEnumerable<string>> result = await _userRules.GetUsersPosts();
                
                foreach (var item in result)
                {
                    PostModel model = new PostModel();
                    model.userName = item.Key;
                    model.posts = item.Value;
                    models.Add(model);
                }
                return Ok(models);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}