using APIExam.Data;
using APIExam.Model;
using APIExam.Model.DTOs;
using APIExam.Services.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

#pragma warning disable                

namespace APIExam.Services.Services
{
    public class ExamFormService : IExamFormService
    {
        private readonly AppDbContext _context;
                    
        public ExamFormService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamFormStudentDto>> GetExamStudentListAsync(
            int collegeId,
            int facultyId,           
            int examId,
            string studentName)
        {    
           
            var rawData = await _context.ExamFormStudentRawDtos
               .FromSqlRaw(
                   "EXEC sp_GetExamFormStudentRegiListData @CollegeId, @FacultyId, @ExamId, @StudentName",
                   new SqlParameter("@CollegeId", collegeId),
                   new SqlParameter("@FacultyId", facultyId),
                   new SqlParameter("@ExamId", examId),
                   new SqlParameter("@StudentName", string.IsNullOrWhiteSpace(studentName) ? DBNull.Value : (object)studentName)
               )
               .AsNoTracking()
               .ToListAsync();

           
            var data = rawData.Select(item => new ExamFormStudentDto
            {
                CollegeCode = item.CollegeCode ?? "",
                RegistrationNo = item.RegistrationNo,
                StudentName = item.StudentName,
                FatherName = item.FatherName,
                MotherName = item.MotherName,
                YearOfPassing = item.YearOfPassing,
                CategoryName = item.CategoryName,
                Faculty = item.Faculty,
                StudentID = item.StudentID ?? 0,
                TransactionId = item.TransactionId,
                IsRegFeeSubmit = item.IsRegFeeSubmit ?? false,
                IsRegFormSubmit = item.IsRegFormSubmit ?? false,
                IsExamFeeSubmit = item.IsExamFeeSubmit ?? false,
                IsExamFormSubmit = item.IsExamFormSubmit ?? false,
                ExamTypeid = item.ExamTypeid ?? 0,


                CorrectionRemarks = item.CorrectionRemarks,
                Status = (item.IsExamFeeSubmit == true && item.IsExamFormSubmit == true) ? "Submitted" :
                item.IsExamFeeSubmit == true ? "Pending" : "Not Paid",
                StatusOrder = (item.IsExamFeeSubmit == true && item.IsExamFormSubmit == true) ? 2 :
                     item.IsExamFeeSubmit == true ? 1 : 0
            }).OrderBy(x => x.StatusOrder).ToList();


            return data;
        }
    }
}