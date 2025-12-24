using APIExam.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class PaymentSummaryController : ControllerBase
        {
            private readonly IPaymentSummaryService _service;

            public PaymentSummaryController(IPaymentSummaryService service)
            {
                _service = service;
            }

            [HttpGet("CollegeWise")]
            public async Task<IActionResult> GetCollegeWiseSummary(int collegeId)
            {
                var data = await _service.GetSummaryAsync(collegeId);

                if (data == null || data.Count == 0)
                    return NotFound("No summary data found");

                return Ok(data);
            }
        }
    }
