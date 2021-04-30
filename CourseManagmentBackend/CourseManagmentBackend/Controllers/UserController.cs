using AutoMapper;
using CourseManagmentBackend.Models;
using CourseManagmentBackend.Models.ViewModels;
using CourseManagmentBackend.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagmentBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public UserController(IUserRepository userRepo, IMapper mapper, ApplicationDbContext context)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            try
            {
                var response = _userRepo.Authenticate(model);

                if (response == null)
                    return BadRequest(new { message = "Korisnicko ime ili lozinka je pogrešno!" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthenticateModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                user = _userRepo.Register(user, model.Password);
                return Ok(new { UserID = user.PkUserId });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult DashboardData()
        {
            var studentsCount = _context.Students.Count();
            var coursesCount = _context.Courses.Count();
            var yearsCount = _context.Year.Count();
            return Ok(new { studentsCount = studentsCount, coursesCount = coursesCount, yearsCount = yearsCount });

        }
    }
}
