using APIExam.Data;
using APIExam.Model;
using APIExam.Model.DTOs;
using APIExam.Services.IServices;
using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Services.Services
{
    public class ExaminationService :IExaminationService
    {
        private readonly AppDbContext _context;

        public ExaminationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DownloadExamFormResponse>> DownloadExamFormAsync(DownloadExaminationFormRequest examinationFormRequest)
        {
            var finalResult = new List<DownloadExamFormResponse>();

            try
            {
                foreach (int studentId in examinationFormRequest.StudentIds)
                {
                    // ⚠️ studentId is SINGLE int — this is key
                    var studentIdParam = new SqlParameter("@StudentID", studentId);
                    var collegeIdParam = new SqlParameter("@CollegeId", examinationFormRequest.CollegeId);
                    var facultyIdParam = new SqlParameter("@FacultyId", examinationFormRequest.FacultyId);
                    var examTypeIdParam = new SqlParameter("@ExamTypeId", examinationFormRequest.ExamTypeId);

                    var data = await _context.DownloadExamFormResponse
                        .FromSqlRaw(
                            "EXEC dbo.GetDwnldExaminationFormData @StudentID, @CollegeId, @FacultyId, @ExamTypeId",
                            studentIdParam, collegeIdParam, facultyIdParam, examTypeIdParam)
                        .AsNoTracking()
                        .ToListAsync();

                    if (data != null && data.Count > 0)
                        finalResult.AddRange(data);
                }

                return finalResult;
            }
            catch (Exception ex)
            {
                // Log the exception (you can use any logging framework)
                throw new ApplicationException("An error occurred while downloading the exam form data.", ex);
            }


        }
    }
}
