using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models.ViewModels
{
    public class CourseViewModel
    {
        public long PkCourseId { get; set; }
        public string NazivKursa { get; set; }
        public List<Student> Studenti { get; set; }
    }
}
