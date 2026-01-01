using APIExam.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PracticalAdmitCardController : ControllerBase
    {
        private readonly IPracticalAdmitCardService _service;

        public PracticalAdmitCardController(IPracticalAdmitCardService service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetPracticalAdmitCard(
            int collegeId, int facultyId, int examId)
        {
            var data = await _service.GetPracticalAdmitCardAsync(
                collegeId, facultyId, examId);

            if (data == null || data.Count == 0)
                return NotFound("No practical admit card data found");

            return Ok(data);
        }
    }
}