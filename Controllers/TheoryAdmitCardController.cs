using APIExam.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{                  
    [ApiController]
    [Route("api/[controller]")]
    public class TheoryAdmitCardController : ControllerBase
    {
        private readonly ITheoryAdmitCardService _service;

       
        public TheoryAdmitCardController(ITheoryAdmitCardService service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetTheoryAdmitCard(
            int collegeId, int facultyId, int examId)
        {
            var data = await _service.GetTheoryAdmitCardAsync(
                collegeId, facultyId, examId);

            if (data == null || data.Count == 0)
                return NotFound("No theory admit card data found");

            return Ok(data);
        }
    }
}

