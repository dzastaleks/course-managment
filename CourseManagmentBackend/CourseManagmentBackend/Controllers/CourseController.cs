using AutoMapper;
using CourseManagmentBackend.Models;
using CourseManagmentBackend.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CourseViewModel model)
        {
            var course = _mapper.Map<Course>(model);
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var course = _context.Courses.FirstOrDefault(s => s.PkCourseId == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }

            return Ok(course);
        }
    }
}
