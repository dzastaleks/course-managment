using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models
{
   
    public class Student
    {
        [Key]
        public long PkStudentID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string BrojIndeksa { get; set; }
        public long YearId { get; set; }
        [ForeignKey("YearId")]
        public Year Year { get; set; }
        public long StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public List<CourseStudent> StudentCourses { get; set; }

    }
}
