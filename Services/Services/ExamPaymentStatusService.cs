using APIExam.Model.DTOs;
using APIExam.Repositories;
using APIExam.Services.IServices;

namespace APIExam.Services.Services
{
    public class ExamPaymentStatusService : IExamPaymentStatusService
    {
        private readonly IExamPaymentStatusRepository _repository;

        public ExamPaymentStatusService(IExamPaymentStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExamPaymentStatusDTO>> GetPaymentDetailsAsync(
            int collegeId,
            string? collegeCode,
            int examId,
            string? clientTxnId)
        {
            return await _repository.GetPaymentDetailsAsync(
                collegeId, collegeCode, examId, clientTxnId);
        }
    }
}