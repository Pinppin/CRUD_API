using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DAL.Models;

namespace WebAPI.BL.Services.Interface
{
    public interface IUserService
    {
        public User AddUser(User user);

        public bool DeleteUser(int id);

        public List<User> GetAllUsers();

        public User GetUserById(int id);

        public User UpdateUser(User user, int userId);

        public User SetTaskToUser(int userId, int taskmodelId);

        public bool DeleteTaskToUser(int userId, int taskmodelId);

        
    }
}
