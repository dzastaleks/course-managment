﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models
{
    public class Course
    {
        [Key]
        public long PkCourseId { get; set; }
        [Required]
        public string NazivKursa { get; set; }
        [JsonIgnore]
        public List<CourseStudent> CourseStudents { get; set; }

    }
}
