using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Models.ViewModels
{
    public class DeleteSelectedCourseStudentsViewModel
    {
        public long PkCourseId { get; set; }
        public long PkStudentID { get; set; }
    }
}
