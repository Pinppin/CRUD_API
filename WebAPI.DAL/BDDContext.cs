using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DAL.Models;

namespace WebAPI.DAL
{
    public class BDDContext : DbContext
    {
        public BDDContext(DbContextOptions<BDDContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<TaskModel> TaskModels { get; set; }


       
    }
}
