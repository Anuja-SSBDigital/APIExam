using APIExam.Model;
using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IExamFormService
    {
        Task<List<ExamFormStudentDto>> GetExamStudentListAsync(
            int collegeId,
            int facultyId,
            int examId,
            string studentName);
    }
}
