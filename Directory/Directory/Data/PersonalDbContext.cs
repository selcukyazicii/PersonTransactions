using Directory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Data
{
    public class PersonalDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=Directory; integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Person>Person { get; set; }
    }
}
