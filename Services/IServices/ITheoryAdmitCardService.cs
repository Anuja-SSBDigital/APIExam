using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface ITheoryAdmitCardService
    {
        Task<List<TheoryAdmitCardDTO>> GetTheoryAdmitCardAsync(
            int collegeId, int facultyId, int examId);
    }
}