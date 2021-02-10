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
    public class TaskModelService : ITaskModelService
    {
        protected readonly BDDContext _demoContext;
        private readonly ILogger _logger;

        public TaskModelService(BDDContext demoContext, ILogger<UserService> logger)
        {
            _demoContext = demoContext;
            _logger = logger;
        }

        public TaskModel AddTaskModel(TaskModel taskmodel)
        {
            try
            {
                _demoContext.TaskModels.Add(taskmodel);
                _demoContext.SaveChanges();
                return taskmodel;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public List<TaskModel> GetAllTask()
        {
            try
            {
                List<TaskModel> tasks = _demoContext.TaskModels.ToList();

                return tasks;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public TaskModel UpdateTaskToUser(TaskModel taskmodel, int taskmodelId)
        {
            try
            {
                TaskModel oldTask = _demoContext.TaskModels.FirstOrDefault(x => x.Id == taskmodelId);
                if (oldTask == null)
                {
                    return null;
                }

                oldTask.Title = taskmodel.Title;
                oldTask.State = taskmodel.State;
                oldTask.Description = taskmodel.Description;
                _demoContext.TaskModels.Update(oldTask);
                _demoContext.SaveChanges();
                return oldTask;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }


        }

        public bool DeleteTask(int id)
        {
            try
            {

                TaskModel taskmodel = _demoContext.TaskModels.FirstOrDefault(x => x.Id == id);

                int state = (int)taskmodel.State;
                if (state == 0)
                {
                    _demoContext.TaskModels.Remove(taskmodel);
                    _demoContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }
    }
}
