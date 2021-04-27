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
    public class YearController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public YearController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] YearViewModel model)
        {
            if (_context.Year.Any(y => y.Naziv == model.Naziv))
                return BadRequest(new { message = "Godina sa ovim nazivom već postoji!" });

            var year = _mapper.Map<Year>(model);
            _context.Year.Add(year);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var years = _context.Year;
            return Ok(new { years = _mapper.Map<List<YearViewModel>>(years) });

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var year = _context.Year.SingleOrDefault(y => y.YearId == id);
            return Ok(new { year = _mapper.Map<YearViewModel>(year) });

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] YearViewModel model)
        {
            if (_context.Year.Any(y => y.Naziv == model.Naziv && y.YearId != model.YearId))
                return BadRequest(new { message = "Godina sa ovim nazivom već postoji!" });

            var year = _mapper.Map<Year>(model);
            _context.Year.Update(year);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var year = _context.Year.FirstOrDefault(y => y.YearId == id);
            if (year != null)
            {
                _context.Year.Remove(year);
                await _context.SaveChangesAsync();
            }

            return Ok(year);
        }
    }
}
