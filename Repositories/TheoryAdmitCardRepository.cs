using APIExam.Data;
using APIExam.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Repositories
{
    public class TheoryAdmitCardRepository : ITheoryAdmitCardRepository
    {
        private readonly AppDbContext _context;

        public TheoryAdmitCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TheoryAdmitCardDTO>> GetTheoryAdmitCardAsync(
            int collegeId, int facultyId, int examId)
        {
            return await _context.TheoryAdmitCards
                .FromSqlRaw(
                    @"EXEC sp_GetExamDummyAdmitCardData 
                        @Fk_CollegeId={0},
                        @Fk_FacultyId={1},
                        @ExamId={2},
                        @IsPractical=NULL,
                        @IsTheory=1",
                    collegeId, facultyId, examId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}