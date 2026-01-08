using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IPhotoSignService
    {
        Task<string>UploadPhotoSignatureAsycn(PhotoSignDTO photoSignDTO);
    }
}
