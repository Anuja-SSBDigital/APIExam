using APIExam.Model.DTOs;

namespace APIExam.Repositories
{
    public interface IPaymentSummaryRepository
    {
        Task<List<ExamFeeFormSummaryDTO>> GetSummaryAsync(int collegeId);
    }
}