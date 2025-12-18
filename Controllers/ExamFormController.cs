using APIExam.Services.IServices;
using APIExam.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{

    [Route("api/[controller]")]
    [ApiController]        
    public class ExamFormController : ControllerBase
    {
        private readonly IExamFormService _service;

        public ExamFormController(IExamFormService service)
        {
            _service = service;    
        }
        [AllowAnonymous]
        [HttpGet("exam-list")]
        public async Task<IActionResult> GetStudentExamList(
     [FromQuery] int collegeId,
     [FromQuery] int facultyId,
     [FromQuery] int examId,
     [FromQuery] string studentName = "")
        {
            var data = await _service.GetExamStudentListAsync(collegeId, facultyId, examId, studentName);

            if (data == null || !data.Any())
                return NotFound(new { message = "No records found" });

            return Ok(data);
        }

    }
}