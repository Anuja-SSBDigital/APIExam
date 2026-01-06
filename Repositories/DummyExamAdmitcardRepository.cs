using APIExam.Data;
using APIExam.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APIExam.Repositories
{
    public class DummyExamAdmitcardRepository:IDummyExamAdmitcardRepository
    {
        private readonly AppDbContext _context;

        public DummyExamAdmitcardRepository(AppDbContext context)
        {
            _context = context;
        }
        
    
        public async Task<List<DummyExamAdmitcarddto>> GetdummyAdmitCardAsync(
            int collegeId, int facultyId, int examId)
        {
            return await _context.DummyExamAdmitcarddto
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