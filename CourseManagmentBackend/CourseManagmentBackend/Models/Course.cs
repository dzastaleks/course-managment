using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models
{
    public class Course
    {
        [Key]
        public long PkCourseId { get; set; }
        [Required]
        public string NazivKursa { get; set; }
        public List<Student> Studenti { get; set; }

    }
}
