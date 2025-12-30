using APIExam.Model.DTOs;

namespace APIExam.Repositories
{
    public interface ITheoryAdmitCardRepository
    {
        Task<List<TheoryAdmitCardDTO>> GetTheoryAdmitCardAsync(
            int collegeId, int facultyId, int examId);
    }
}