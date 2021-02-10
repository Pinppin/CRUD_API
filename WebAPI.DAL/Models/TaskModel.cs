using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DAL.Models
{
    public class TaskModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public State State { get; set; }
        public string Description { get; set; }
    }

    public enum State
    {
        todo = 0,
        inprogress = 1,
        done = 2

    }
}
