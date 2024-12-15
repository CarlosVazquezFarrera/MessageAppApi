using MessageApp.DTOs;
using MessageApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        private readonly IStudentService _studentService;
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginInfo info)
        {
            var student = await _studentService.Login(info);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentDTO student)
        {
            var newStudent = await _studentService.Create(student);
            return Ok(newStudent);
        }
    }
}
