
using APIExam.Data;
using APIExam.Model;
using APIExam.Services.IServices;
using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Services.Services
{
    public class DwnldExmFrmService : IDwnldExmFrmService
    {
        private readonly AppDbContext _context;

        public DwnldExmFrmService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student_Mst>> DownloadExamFormAsync(DonwloadExamformModel dwnldModel)
        {
            try
            {
                var CollegeId = new SqlParameter("@CollegeId", dwnldModel.CollegeId);

                var StudentName = new SqlParameter("@StudentName",
                    string.IsNullOrWhiteSpace(dwnldModel.StudentName)
                        ? ""
                        : dwnldModel.StudentName);

                var FacultyId = new SqlParameter("@FacultyId", dwnldModel.FacultyId);

                var ExamId = new SqlParameter("@ExamId", dwnldModel.ExamId);

                var CategoryName = new SqlParameter("@CategoryName",
                    string.IsNullOrWhiteSpace(dwnldModel.CategoryName)
                        ? ""
                        : dwnldModel.CategoryName);

                var SubCategory = new SqlParameter("@SubCategory",
                    string.IsNullOrWhiteSpace(dwnldModel.SubCategory)
                        ? ""
                        : dwnldModel.SubCategory);


                var result = await _context.Student_Mst
    .FromSqlRaw(
        "EXEC sp_GetExamDwnldStudentData @CollegeId, @StudentName, @FacultyId, @ExamId, @CategoryName, @SubCategory",
        CollegeId, StudentName, FacultyId, ExamId, CategoryName, SubCategory)
    
    .ToListAsync();


                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public Task<DonwloadExamformModel> DownloadExamFormAsync(DonwloadExamformModel donwloadExamformModel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
