using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IStudentRegisteredListService
    {
        Task<List<StudentRegisteredListdto>> GetStudentRegisteredListAsync(
           int collegeId,
           int facultyId,
           int examId
          );
    }
}
