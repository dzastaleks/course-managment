using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models.ViewModels
{
    public class CourseViewModel
    {
        public long PkCourseId { get; set; }
        public string NazivKursa { get; set; }
        [JsonIgnore]
        public List<CourseStudent> CourseStudents { get; set; }
        public int StudentsCount { get; set; }
    }
}
