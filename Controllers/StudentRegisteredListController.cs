using APIExam.Repositories;
using APIExam.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{
           
    [ApiController]
    [Route("api/StudentRegisteredList")]
    public class StudentRegisteredListController : Controller
    {
        private readonly IStudentRegisteredListService _service;

        public StudentRegisteredListController(IStudentRegisteredListService service)
        {
            _service = service;     
        }
                  
      
        [AllowAnonymous]
        [HttpGet("StudentRegisteredList")]
        public async Task<IActionResult> StudentRegisteredList(
    [FromQuery] int collegeId,
    [FromQuery] int facultyId,
    [FromQuery] int examId)
        {
            var data = await _service.GetStudentRegisteredListAsync(
                collegeId, facultyId, examId);

            if (data == null || !data.Any())
                return NotFound(new { message = "No records found" });

            return Ok(data);
        }
    }
}