using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models
{
    public class CourseStudent
    {
        [Key]
        public long PkCourseId { get; set; }
        public Course Course { get; set; }
        [Key]
        public long PkStudentID { get; set; }
        public Student Student { get; set; }
    }
}
