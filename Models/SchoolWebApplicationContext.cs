using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolWebApplication.Models
{
    public class SchoolWebApplicationContext: DbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<SchoolType> SchoolTypes { get; set; }
        public virtual DbSet<TeacherType> TeacherTypes { get; set; }
        public virtual DbSet<TeachersClasses> TeachersClasses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public SchoolWebApplicationContext(DbContextOptions <SchoolWebApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
