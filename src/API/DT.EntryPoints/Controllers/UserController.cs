using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DT.BusinessRules.Contracts;

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
                return Ok(await _userRules.GetUsersTodos());
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
                return Ok(await _userRules.GetUsersPosts());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}