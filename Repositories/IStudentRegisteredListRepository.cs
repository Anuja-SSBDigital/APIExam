using APIExam.Model.DTOs;

namespace APIExam.Repositories
{
    public interface IStudentRegisteredListRepository
    {

       
        Task<List<StudentRegisteredListsqlRow>> GetExamStudentRawListAsync(
           int collegeId,
           int facultyId,
           int examId
       );
    }
}

