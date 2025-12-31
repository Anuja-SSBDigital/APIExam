using APIExam.Model.DTOs;

namespace APIExam.Repositories
{
    public interface IPracticalAdmitCardRepository
    {
        Task<List<PracticalAdmitCardDTO>> GetPracticalAdmitCardAsync(
            int collegeId, int facultyId, int examId);
    }
}