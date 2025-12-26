using APIExam.Model.DTOs;

namespace APIExam.Repositories
{
    public interface IExamPaymentStatusRepository
    {
        Task<List<ExamPaymentStatusDTO>> GetPaymentDetailsAsync(
            int collegeId,
            string? collegeCode,
            int examId,
            string? clientTxnId
        );
    }
}