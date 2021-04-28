using AutoMapper;
using CourseManagmentBackend.Models;
using CourseManagmentBackend.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseViewModel model)
        {
            if(_context.Courses.Any(c=>c.NazivKursa == model.NazivKursa))
                return BadRequest(new { message = "Naziv kursa je već u upotrebi" });

            var course = _mapper.Map<Course>(model);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = _context.Courses;
            return Ok(new { courses = _mapper.Map<List<CourseViewModel>>(courses) });

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.PkCourseId == id);
            return Ok( new { course = _mapper.Map<CourseViewModel>(course) });

        }
        [HttpGet("get-details-for-course/{id}")]
        public async Task<IActionResult> GetDetails(long id)
        {
            var course = _context.Courses.FromSqlRaw<Course>("spGetCourseDetails {0}", id).ToList().FirstOrDefault();
            //if (course != null)
                //course.CourseStudents = _context.Students.FromSqlRaw<Student>("spGetStudentsForCourse {0}", id).ToList();
          
            return Ok(new { course = _mapper.Map<Course>(course) });

        }
        [HttpGet("get-students-for-course/{id}")]
        public async Task<IActionResult> GetStudents(long id)
        {
            var students = _context.Students.FromSqlRaw<Student>("spGetStudentsForCourse {0}", id).ToList();
            //if (course != null)
            //course.CourseStudents = _context.Students.FromSqlRaw<Student>("spGetStudentsForCourse {0}", id).ToList();

            List<StudentViewModel> studentView = new List<StudentViewModel>();
            foreach (var item in students)
            {
                studentView.Add(_mapper.Map<StudentViewModel>(item));
            }
            return Ok(new { studenti = studentView });

        }
        [HttpGet("get-students-not-in-course/{id}")]
        public async Task<IActionResult> GetStudentsNotIn(long id)
        {

            var studentsInCourse = _context.CourseStudent.Where(cs => cs.PkCourseId == id).Select(cs => cs.PkStudentID);

            var students = _context.Students.Where(s => !studentsInCourse.Contains(s.PkStudentID)).ToList();


            return Ok(new { students = _mapper.Map<List<StudentViewModel>>(students) });

        }

        [HttpPost("delete-selected-students-from-course")]
        public async Task<IActionResult> DeleteSelectedStudents([FromBody] List<DeleteSelectedCourseStudentsViewModel> selected)
        {
            foreach (var item in selected)
            {
                var student = _context.CourseStudent.FirstOrDefault(c => c.PkCourseId == item.PkCourseId && c.PkStudentID == item.PkStudentID);
                if (student != null)
                {
                    _context.CourseStudent.Remove(student);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok();
        }
        [HttpPost("add-selected-students-to-course")]
        public async Task<IActionResult> AddSelectedStudents([FromBody] List<DeleteSelectedCourseStudentsViewModel> selected)
        {
            try
            {
                foreach (var item in selected)
                {
                    if (!_context.CourseStudent.Any(cs => cs.PkStudentID.Equals(item.PkStudentID) && cs.PkCourseId.Equals(item.PkCourseId)))
                    {

                        _context.CourseStudent.Add(new CourseStudent() { PkCourseId = item.PkCourseId, PkStudentID = item.PkStudentID });
                        await _context.SaveChangesAsync();
                    }
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CourseViewModel model)
        {
            if (_context.Courses.Any(c => c.NazivKursa == model.NazivKursa && c.PkCourseId != model.PkCourseId))
                return BadRequest(new { message = "Naziv kursa je već u upotrebi" });

            var course = _mapper.Map<Course>(model);
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.PkCourseId == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }

            return Ok(course);
        }
    }
}
