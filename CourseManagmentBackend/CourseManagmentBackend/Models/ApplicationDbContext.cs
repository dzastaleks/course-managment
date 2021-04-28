using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace CourseManagmentBackend.Models
{

    public class ApplicationDbContext : DbContext { 


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public  DbSet<Student> Students { get; set; }
        public  DbSet<Course> Courses { get; set; }
        public  DbSet<Year> Year { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseStudent>()
           .HasKey(cs => new { cs.PkCourseId, cs.PkStudentID});

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.PkCourseId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(c=> c.StudentCourses)
                .HasForeignKey(cs => cs.PkStudentID);


        }

    
    }
}
