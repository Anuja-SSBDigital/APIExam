using APIExam.Data;
using APIExam.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Repositories
{
    public class PracticalAdmitCardRepository : IPracticalAdmitCardRepository
    {
        private readonly AppDbContext _context;

        public PracticalAdmitCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PracticalAdmitCardDTO>> GetPracticalAdmitCardAsync(
            int collegeId, int facultyId, int examId)
        {
            return await _context.PracticalAdmitCards
                .FromSqlRaw(
                    @"EXEC sp_GetExamDummyAdmitCardData
                        @Fk_CollegeId={0},
                        @Fk_FacultyId={1},
                        @ExamId={2},
                        @IsPractical=1,
                        @IsTheory=NULL",
                    collegeId, facultyId, examId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
