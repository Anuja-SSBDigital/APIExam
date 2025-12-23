using APIExam.Data;
using APIExam.Model;
using APIExam.Model.DTOs;
using APIExam.Services.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Services.Services
{
    public class ExamPaymentService : IExamPaymentService
    {
        private readonly AppDbContext _context;

        public ExamPaymentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExampaymentResponseDTO>> ExamPaymentAsync(DonwloadExamformModel examformModel)
        {

            try
            {
                var result = new List<ExampaymentResponseDTO>();

                var CollegeId = new SqlParameter("@CollegeId", examformModel.CollegeId);
                var StudentName = new SqlParameter("@StudentName", examformModel.StudentName ?? (object)DBNull.Value);
                var FacultyId = new SqlParameter("@FacultyId", examformModel.FacultyId);
                var ExamId = new SqlParameter("@ExamId", examformModel.ExamId ?? (object)DBNull.Value);
                var CategoryName = new SqlParameter("@CategoryName", examformModel.CategoryName ?? (object)DBNull.Value);
                var SubCategory = new SqlParameter("@SubCategory", "makepayment");

                result = await _context.exampaymentResponseDTOs
                    .FromSqlRaw("EXEC dbo.sp_GetExamDwnldStudentData @CollegeId, @StudentName, @FacultyId, @ExamId, @CategoryName, @SubCategory",
                        CollegeId, StudentName, FacultyId, ExamId, CategoryName, SubCategory)
                    .ToListAsync();

                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
