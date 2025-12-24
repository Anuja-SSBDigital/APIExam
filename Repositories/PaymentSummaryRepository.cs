using APIExam.Data;
using APIExam.Model.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Repositories
{
    public class PaymentSummaryRepository : IPaymentSummaryRepository
    {
        private readonly AppDbContext _context;

        public PaymentSummaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamFeeFormSummaryDTO>> GetSummaryAsync(int collegeId)
        {
            var param = new SqlParameter("@CollegeId", collegeId);

            return await _context.ExamFeeFormSummaryDTOs
                .FromSqlRaw("EXEC dbo.sp_GetExamFeeFormSummary @CollegeId", param)
                .ToListAsync();
        }
    }
}