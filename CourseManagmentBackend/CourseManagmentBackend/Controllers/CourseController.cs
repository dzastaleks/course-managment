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
