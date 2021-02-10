using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DAL.Models;

namespace WebAPI.BL.Services.Interface
{
    public interface ITaskModelService
    {
        public TaskModel AddTaskModel(TaskModel taskmodel);

        public List<TaskModel> GetAllTask();

        public TaskModel UpdateTaskToUser(TaskModel taskmodel,int taskmodelId);

        public bool DeleteTask(int id);
    }
}
