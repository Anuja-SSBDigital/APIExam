using APIExam.Model.DTOs;
using APIExam.Repositories;
using APIExam.Services.IServices;

namespace APIExam.Services.Services
{
    public class PaymentSummaryService : IPaymentSummaryService
    {
        private readonly IPaymentSummaryRepository _repository;

        public PaymentSummaryService(IPaymentSummaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExamFeeFormSummaryDTO>> GetSummaryAsync(int collegeId)
        {
            return await _repository.GetSummaryAsync(collegeId);
        }
    }
}
