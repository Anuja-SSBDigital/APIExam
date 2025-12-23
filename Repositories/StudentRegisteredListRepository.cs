using APIExam.Data;
using APIExam.Model.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Repositories
{
    public class StudentRegisteredListRepository : IStudentRegisteredListRepository
    {
        private readonly AppDbContext _context;

        public StudentRegisteredListRepository(AppDbContext context)
        {
            _context = context;
        }   
           
        
        public async Task<List<StudentRegisteredListsqlRow>> GetExamStudentRawListAsync(
            int collegeId,
            int facultyId,
            int examId
        )
        {
            return await _context.StudentRegisteredListsqlRow
                .FromSqlRaw(
                    "EXEC sp_GetStudentExaminationListData @CollegeId, @FacultyId, @ExamId",
                    new SqlParameter("@CollegeId", collegeId),
                    new SqlParameter("@FacultyId", facultyId),
                    new SqlParameter("@ExamId", examId)
                )
                .AsNoTracking()
                .ToListAsync();
        }
    }
}