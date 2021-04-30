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
        }
    }
}
