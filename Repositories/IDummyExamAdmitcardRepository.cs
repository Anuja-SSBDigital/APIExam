using APIExam.Model.DTOs;

namespace APIExam.Repositories
{
    public interface IDummyExamAdmitcardRepository
    {

        Task<List<DummyExamAdmitcarddto>> GetdummyAdmitCardAsync(
         int collegeId, int facultyId, int examId);
    }
}
