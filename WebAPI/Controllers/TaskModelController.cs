using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BL.Services;
using WebAPI.BL.Services.Interface;
using WebAPI.DAL.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskModelController : ControllerBase
    {
        private ITaskModelService _taskmodelService;

        public TaskModelController(ITaskModelService taskmodelService)
        {
            _taskmodelService = taskmodelService;
        }

        [HttpPost("AddTask")]
        public TaskModel AddTaskModel(TaskModel taskmodel)
        {
            return _taskmodelService.AddTaskModel(taskmodel);
        }

        [HttpGet("GetAllTask")]
        public List<TaskModel> GetAllTask()
        {
            return _taskmodelService.GetAllTask();
        }

        [HttpPut("UpdateTask")]
        public TaskModel UpdateTaskToUser(TaskModel taskmodel, int taskmodelId)
        {
            return _taskmodelService.UpdateTaskToUser(taskmodel,taskmodelId);
        }

        [HttpDelete("DeleteTask")]
        public bool DeleteTask(int id)
        {
            return _taskmodelService.DeleteTask(id);
        }
    }
}
