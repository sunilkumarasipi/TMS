using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TMS.Data.Models;

namespace TMS.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {
                
        }
        public DbSet<School> School { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }
    }
}
