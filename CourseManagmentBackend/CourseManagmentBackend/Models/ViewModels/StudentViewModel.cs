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
        public long YearId { get; set; }
        public long StatusId { get; set; }
        public List<Course> Kursevi { get; set; }
    }
}
