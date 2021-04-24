using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models.ViewModels
{
    public class StudentViewModel
    {
        public long PkStudentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }
        public Year Year { get; set; }
        public Status Status { get; set; }
        public List<Course> Kursevi { get; set; }
    }
}
