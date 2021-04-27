using AutoMapper;using CourseManagmentBackend.Models;
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
            CreateMap<Student, StudentViewModel>().ForMember(svm => svm.YearId, m => m.MapFrom(s => s.Year.YearId)).ForMember(svm => svm.StatusId, m => m.MapFrom(s => s.Status.StatusId));
            CreateMap<StudentViewModel, Student>();
            CreateMap<Year, YearViewModel>().ReverseMap();
            CreateMap<AuthenticateModel, User>();
        }
    }
}
