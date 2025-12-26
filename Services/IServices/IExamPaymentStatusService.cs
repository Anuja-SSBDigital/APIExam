using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IExamPaymentStatusService
    {
        Task<List<ExamPaymentStatusDTO>> GetPaymentDetailsAsync(
            int collegeId,
            string? collegeCode,
            int examId,
            string? clientTxnId
        );
    }
}