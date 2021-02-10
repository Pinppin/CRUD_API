using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BL.Services.Interface;
using WebAPI.DAL.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddUser")]
        public User Post(User user)
        {
            return _userService.AddUser(user);
        }

        [HttpDelete("DeleteUser")]
        public bool Delete(int id)
        {
            return _userService.DeleteUser(id);
        }

        [HttpDelete("DeleteTaskToUser")]
        public bool DeleteTaskToUser(int userId, int taskmodelId)
        {
            return _userService.DeleteTaskToUser(userId,taskmodelId);
        }

        [HttpGet("GetAllUser")]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("GetUserById")]
        public User Get(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPut("UpdateUser")]
        public User UpdateUser(User user, int userId)
        {
            return _userService.UpdateUser(user,userId);
        }

        [HttpPut("SetTaskToUser")]
        public User SetTaskToUser(int userId, int taskmodelId)
        {
            return _userService.SetTaskToUser(userId, taskmodelId);
        }
    }
}
