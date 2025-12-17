using APIExam.Model;
using APIExam.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

        [HttpPost("ExamFormDetails")]
        public async Task<IActionResult> ExamFormDetails([FromForm] DownloadExaminationFormRequest examinationFormRequest)
        {
            try
            {
                var result = await _examinationService.DownloadExamFormAsync(examinationFormRequest);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Failed to download exam form.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
