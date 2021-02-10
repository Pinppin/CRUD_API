using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BL.Services.Interface;
using WebAPI.DAL;
using WebAPI.DAL.Models;

namespace WebAPI.BL.Services
{
    public class UserService : IUserService
    {
        protected readonly BDDContext _demoContext;
        private readonly ILogger _logger;

        public UserService(BDDContext demoContext,ILogger<UserService> logger)
        {
            _demoContext = demoContext;
            _logger = logger;
        }

        public User AddUser(User user)
        {
            try
            {
                _demoContext.Users.Add(user);
                _demoContext.SaveChanges();

                return user;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                User user = _demoContext.Users.FirstOrDefault(x => x.Id == id);
                _demoContext.Users.Remove(user);
                _demoContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                List<User> users = _demoContext.Users.Include(x => x.TaskModels).ToList();

                return users;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }


        public User GetUserById(int id)
        {
            try
            {
                User user = _demoContext.Users.Include(x => x.TaskModels).FirstOrDefault(x => x.Id == id);
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public User UpdateUser(User user, int userId)
        {
            try
            {
                User oldUser = _demoContext.Users.FirstOrDefault(x => x.Id == userId);
                if(oldUser == null)
                {
                    return null;
                }

                oldUser.Username = user.Username;
                _demoContext.Users.Update(oldUser);
                _demoContext.SaveChanges();
                return oldUser;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public User SetTaskToUser(int userId, int taskmodelId)
        {
            try
            {
                User user = _demoContext.Users.FirstOrDefault(x => x.Id == userId);
                TaskModel taskmodel = _demoContext.TaskModels.FirstOrDefault(x => x.Id == taskmodelId);

                if(user.TaskModels == null)
                {
                    user.TaskModels = new List<TaskModel>();
                }

                user.TaskModels.Add(taskmodel);
                _demoContext.Users.Update(user);
                _demoContext.SaveChanges();
                return user;

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public bool DeleteTaskToUser(int userId, int taskmodelId)
        {
            User user = _demoContext.Users.FirstOrDefault(x => x.Id == userId);
            TaskModel taskmodel = _demoContext.TaskModels.FirstOrDefault(x => x.Id == taskmodelId);
            try
            {
                int state = (int)taskmodel.State;
                if (state == 0)
                {
                    _demoContext.TaskModels.Remove(taskmodel);
                    _demoContext.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }


    }
}
