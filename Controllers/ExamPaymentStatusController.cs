using APIExam.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers       
{
      
    [ApiController]
    [Route("api/[controller]")]
    public class ExamPaymentStatusController : ControllerBase
    {
        private readonly IExamPaymentStatusService _service;

        public ExamPaymentStatusController(IExamPaymentStatusService service)
        {
            _service = service;
        }

        [HttpGet("GetPaymentDetails")]
        public async Task<IActionResult> GetPaymentDetails(
            int collegeId,
            int examId,
            string? collegeCode = null,
            string? clientTxnId = null)
        {
            var result = await _service.GetPaymentDetailsAsync(
                collegeId, collegeCode, examId, clientTxnId);

            if (result == null || result.Count == 0)
                return NotFound("No payment record found");

            return Ok(result);
        }
    }
}

