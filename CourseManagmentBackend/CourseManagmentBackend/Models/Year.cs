using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models
{
    public class Year
    {
        public long YearId { get; set; }
        [Required]
        public string Naziv { get; set; }
    }
}
