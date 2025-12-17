using APIExam.Data;
using APIExam.Model;
using APIExam.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DwnldExmFrmController : ControllerBase
    {
        private readonly IDwnldExmFrmService dwnldExmFrmService;

      public DwnldExmFrmController (IDwnldExmFrmService _dwnldExmFrmService)
        {
            dwnldExmFrmService= _dwnldExmFrmService;
        }

        [HttpPost("DownloadExamForm")]
        public async Task<IActionResult> DownloadExamForm([FromForm] DonwloadExamformModel donwloadExamformModel)
        {
            try
            {
                var result = await dwnldExmFrmService.DownloadExamFormAsync(donwloadExamformModel);
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
        //public async Task<IActionResult> DownloadExamForm([FromQuery]int collegeId)
        //{
        //    var result = await dwnldExmFrmService.DownloadExamFormAsync(collegeId);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest("Failed to download exam form.");
        //    }
        //}
    }
}
