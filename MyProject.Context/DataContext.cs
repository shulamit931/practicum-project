using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Context
{
    public class DataContext :DbContext,IContext
    {
        public DbSet<Person> People { get; set; }

  
        public EntityEntry GetEntity(object entity)
        {
            return Entry(entity);
        }

        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {

        }
    }
}
