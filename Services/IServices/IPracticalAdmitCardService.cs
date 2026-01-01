using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IPracticalAdmitCardService
    {
        Task<List<PracticalAdmitCardDTO>> GetPracticalAdmitCardAsync(
            int collegeId, int facultyId, int examId);
    }
}