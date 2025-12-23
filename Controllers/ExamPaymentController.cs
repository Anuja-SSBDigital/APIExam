using APIExam.Model;
using APIExam.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamPaymentController : ControllerBase
    {

        private readonly IExamPaymentService _examPaymentService;

        public ExamPaymentController(IExamPaymentService examPaymentService)
        {
            _examPaymentService = examPaymentService;
        }

        [HttpPost("ExamPayment")]
        public async Task<IActionResult> ExamPayment([FromForm] DonwloadExamformModel examformModel)
        {
            try
            {
                var result = await _examPaymentService.ExamPaymentAsync(examformModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use any logging framework)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}
