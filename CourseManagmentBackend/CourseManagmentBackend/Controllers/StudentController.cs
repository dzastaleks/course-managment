using AutoMapper;
using CourseManagmentBackend.Models;
using CourseManagmentBackend.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StudentController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentViewModel model)
        {
            if(_context.Students.Any(s=>s.BrojIndeksa == model.BrojIndeksa))
                return BadRequest(new { message = "Student sa ovim brojem indeksa vec postoji" });


            var student = _mapper.Map<Student>(model);

            var year = await _context.Year.FindAsync(model.YearId);
            var status = await _context.Status.FindAsync(model.StatusId);
            
            student.Year = year;
            student.Status = status;
            
            _context.Students.Add(student);
            await _context.SaveChangesAsync(); 
;           return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var students = _context.Students.Include(s => s.Year).Include(s => s.Status).Include(s => s.StudentCourses)
                       .Select(s => new StudentViewModel()
                       {
                           PkStudentID = s.PkStudentID,
                           Ime = s.Ime,
                           Prezime = s.Prezime,
                           BrojIndeksa = s.BrojIndeksa,
                           Year = s.Year,
                           Status = s.Status,
                           CoursesCount = s.StudentCourses.Count()
                       })
                       .ToList();
            return Ok(new { students = _mapper.Map<List<StudentViewModel>>(students)});

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var student = _context.Students.Include(s => s.Status).Include(s => s.Year).FirstOrDefault(s => s.PkStudentID == id);


            return Ok(new { student = _mapper.Map<StudentViewModel>(student) });


        }
        [HttpGet("get-details-for-student/{id}")]
        public async Task<IActionResult> GetDetails(long id)
        {
            var student = _context.Students.FromSqlRaw<Student>("spGetStudentDetails {0}", id).ToList().FirstOrDefault();
            if (student != null)
            {
                student.Year = _context.Year.FromSqlRaw<Year>("spGetYearForStudent {0}", id).ToList().FirstOrDefault();
                student.Status = _context.Status.FromSqlRaw<Status>("spGetStatusForStudent {0}", id).ToList().FirstOrDefault();
            }
            
            return Ok(new { student = _mapper.Map<Student>(student) });
        }
        [HttpGet("get-courses-for-student/{id}")]
        public async Task<IActionResult> GetCourses(long id)
        {
            // var courses = _context.CourseStudent.Include(c => c.Course).Where(s=> s.PkStudentID == id);
            var courses = _context.Courses.FromSqlRaw<Course>("spGetCoursesForStudent {0}", id).ToList();


            List<CourseViewModel> courseView = new List<CourseViewModel>();
            foreach (var item in courses)
            {
                courseView.Add(_mapper.Map<CourseViewModel>(item));
            }
            return Ok(new { kursevi = courseView });
        }
        [HttpPut]   
        public async Task<IActionResult> Update([FromBody] StudentViewModel model)
        {
            if (_context.Students.Any(s => s.BrojIndeksa == model.BrojIndeksa && s.PkStudentID != model.PkStudentID))
                return BadRequest(new { message = "Student sa ovim brojem indeksa vec postoji" });

            var student = _mapper.Map<Student>(model);

            var year = await _context.Year.FindAsync(model.YearId);
            var status = await _context.Status.FindAsync(model.StatusId);

            student.Year = year;
            student.Status = status;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var student = _context.Students.FirstOrDefault(s => s.PkStudentID == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }

            return Ok(student);
        }
    }
}
