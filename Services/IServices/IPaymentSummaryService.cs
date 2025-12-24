using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IPaymentSummaryService
    {
        Task<List<ExamFeeFormSummaryDTO>> GetSummaryAsync(int collegeId);
    }
}
