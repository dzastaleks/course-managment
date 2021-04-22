using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models
{
    public enum Status
    {
        Redovni,
        Vanredni
    }
    public class Student
    {
        [Key]
        public long PkStudentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }
        public int Godina { get; set; }
        public Status Status { get; set; }
        public List<Course> Kursevi { get; set; }
    }
}
