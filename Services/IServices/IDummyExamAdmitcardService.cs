using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IDummyExamAdmitcardService
    {
        Task<List<DummyExamAdmitcarddto>> GetdummyAdmitCardAsync(
         int collegeId, int facultyId, int examId);
    }
}
