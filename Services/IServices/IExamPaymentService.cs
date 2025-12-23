using APIExam.Model;
using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IExamPaymentService
    {
        Task<List<ExampaymentResponseDTO>> ExamPaymentAsync(DonwloadExamformModel examformModel);
    }
}
