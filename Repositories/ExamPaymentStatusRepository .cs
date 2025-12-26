using APIExam.Data;
using APIExam.Model.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Repositories
{
    public class ExamPaymentStatusRepository : IExamPaymentStatusRepository
    {
        private readonly AppDbContext _context;

        public ExamPaymentStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamPaymentStatusDTO>> GetPaymentDetailsAsync(
            int collegeId,
            string? collegeCode,
            int examId,
            string? clientTxnId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CollegeId", collegeId),
                new SqlParameter("@CollegeCode", (object?)collegeCode ?? DBNull.Value),
                new SqlParameter("@ClientTxnId", (object?)clientTxnId ?? DBNull.Value),
                new SqlParameter("@ExamId", examId)
            };

            return await _context.ExamPaymentStatusDTOs
                .FromSqlRaw(
                    "EXEC dbo.sp_GetExamPaymentDetails @CollegeId, @CollegeCode, @ClientTxnId, @ExamId",
                    parameters)
                .ToListAsync();
        }
    }
}