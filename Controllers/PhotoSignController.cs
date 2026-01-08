using APIExam.Model.DTOs;
using APIExam.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoSignController : ControllerBase
    {
        private readonly IPhotoSignService _photoSignService;

        public PhotoSignController(IPhotoSignService photoSignService)
        {
            _photoSignService = photoSignService;
        }


        [AllowAnonymous]
        [HttpPost("Upload-PhotoSign")]
        public async Task<IActionResult> UploadPhotoSign([FromForm] PhotoSignDTO photoSignDTO)
        {
            try
            {
                var result = await _photoSignService.UploadPhotoSignatureAsycn(photoSignDTO);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
