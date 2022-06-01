using learninganularapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learninganularapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration configuration;
        public AccountController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
         
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser (UserMaster userModel)
        {
            try
            {
                DataAccess db = new DataAccess(configuration);
                UserMaster user = db.CreateUser(userModel);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                DataAccess db = new DataAccess(configuration);
                IList<UserMaster> user = db.GetAllUsers();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
