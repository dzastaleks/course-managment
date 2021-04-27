using AutoMapper;
using CourseManagmentBackend.Models;
using CourseManagmentBackend.Models.ViewModels;
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
            var students = _context.Students.Include(s => s.Year).Include(s => s.Status);
            return Ok(new { students = _mapper.Map<List<StudentViewModel>>(students)});

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var student =  _context.Students.Include(s => s.Status).Include(s => s.Year).FirstOrDefault(s => s.PkStudentID == id);
            return Ok(new { student = _mapper.Map<StudentViewModel>(student) });


        }
        [HttpGet("get-details-for-student/{id}")]
        public async Task<IActionResult> GetDetails(long id)
        {
            var student = _context.Students.FromSqlRaw("spGetStudentById {0}", id).ToList().FirstOrDefault();
            return Ok(new { student = _mapper.Map<StudentViewModel>(student) });
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
