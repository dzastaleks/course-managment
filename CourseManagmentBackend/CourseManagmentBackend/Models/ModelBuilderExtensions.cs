using CourseManagmentBackend.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                    new Status
                    {
                        StatusId = 1,
                        Naziv = "Redovan"

                    },
                    new Status
                    {
                        StatusId = 2,
                        Naziv = "Vanredni"
                    }
                );
            modelBuilder.Entity<Year>().HasData(
                new Year
                {
                    YearId = 1,
                    Naziv = "Prva"

                },
                new Year
                {
                    YearId = 2,
                    Naziv = "Druga"
                },
                 new Year
                 {
                     YearId = 3,
                     Naziv = "Treća"
                 },
                  new Year
                  {
                      YearId = 4,
                      Naziv = "Četvrta"
                  }
            );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    PkStudentID = 1,
                    Ime = "Marko",
                    Prezime = "Marković",
                    BrojIndeksa = "123/15",
                    YearId = 1,
                    StatusId = 1
                },
                new Student
                {
                    PkStudentID = 2,
                    Ime = "Petar",
                    Prezime = "Petrović",
                    BrojIndeksa = "124/15",
                    YearId = 2,
                    StatusId = 2
                },
                new Student
                {
                    PkStudentID = 4,
                    Ime = "Marko",
                    Prezime = "Petrović",
                    BrojIndeksa = "125/15",
                    YearId = 1,
                    StatusId = 1
                },
                new Student
                {
                    PkStudentID = 5,
                    Ime = "Petar",
                    Prezime = "Marković",
                    BrojIndeksa = "126/15",
                    YearId = 1,
                    StatusId = 1

                }
            );
            modelBuilder.Entity<Course>().HasData(
              new Course
              {
                  PkCourseId = 1,
                  NazivKursa = "Asp.net"
              },
             new Course
             {
                 PkCourseId = 2,
                 NazivKursa = "Vuejs"
             },
             new Course
             {
                 PkCourseId = 3,
                 NazivKursa = ".Net core"
             },
             new Course
             {
                 PkCourseId = 4,
                 NazivKursa = "Python"
             }
          );
            modelBuilder.Entity<CourseStudent>().HasData(
              new CourseStudent
              {
                  PkCourseId = 1,
                  PkStudentID = 1
              },
             new CourseStudent
             {
                 PkCourseId = 1,
                 PkStudentID = 2
             },
             new CourseStudent
             {
                 PkCourseId = 2,
                 PkStudentID = 1
             },
             new CourseStudent
             {
                 PkCourseId = 3,
                 PkStudentID = 1
             }
           );
            modelBuilder.Entity<User>().HasData(
              new User
              {
                  PkUserId = new Guid("f47723ed-995d-49e5-4ef6-08d90c2820f9"),
                  Username = "administrator",
                  PasswordHash = new byte[] { 95, 4, 15, 89, 248, 149, 241, 102, 21, 65, 34, 103, 32, 225, 203, 169, 136, 224, 62, 68, 250, 30, 15, 23, 219, 68, 62, 25, 23, 194, 174, 80, 0, 59, 82, 4, 170, 203, 85, 121, 253, 89, 10, 181, 151, 106, 100, 136, 247, 121, 61, 71, 176, 92, 235, 45, 174, 179, 248, 236, 46, 208, 179, 166 },
                  PasswordSalt = new byte[] {25, 226, 208, 127, 16, 122, 158, 79, 194, 68, 237, 79, 113, 197, 32, 25, 74, 79, 217, 51, 21, 137, 131, 144, 58, 94, 139, 89, 173, 246, 126, 205, 196, 243, 27, 190, 52, 66, 157, 78, 19, 209, 188, 88, 33, 58, 114, 78, 221, 65, 204, 111, 27, 235, 84, 33, 11, 180, 141, 188, 199, 27, 174, 121, 235, 126, 226, 170, 238, 89, 234, 229, 191, 158, 132, 105, 206, 149, 129, 3, 215, 28, 184, 210, 127, 80, 208, 10, 179, 69, 97, 170, 174, 200, 125, 37, 220, 82, 9, 115, 87, 63, 85, 69, 171, 112, 34, 82, 18, 64, 12, 150, 209, 90, 240, 212, 55, 16, 153, 158, 47, 4, 200, 177, 230, 209, 240, 113}
              }
           );
        }
    }
}
