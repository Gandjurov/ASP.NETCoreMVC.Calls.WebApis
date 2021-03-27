using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData
            (
                new Student { Id = 1, Name = "Lewis Hamilton" },
                new Student { Id = 2, Name = "Laren Buffet" },
                new Student { Id = 3, Name = "Elon Musk" }
            );
            //base.OnModelCreating(modelBuilder);
        }
    }
}
