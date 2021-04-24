using AutoMapper;
using CourseManagmentBackend.Models;
using CourseManagmentBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Mapper
{
    public class CourseMappings : Profile
    {
        public CourseMappings()
        {
            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Year, YearViewModel>().ReverseMap();
        }
    }
}
