using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public List<TaskModel> TaskModels { get; set; }
    }
}
