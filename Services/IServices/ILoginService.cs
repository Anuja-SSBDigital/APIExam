using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
