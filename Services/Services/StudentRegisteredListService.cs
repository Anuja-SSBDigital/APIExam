using APIExam.Model.DTOs;
using APIExam.Repositories;
using APIExam.Repositories.IRepositories;
using APIExam.Services.IServices;

namespace APIExam.Services.Services      
{
    public class StudentRegisteredListService : IStudentRegisteredListService
    {
        private readonly IStudentRegisteredListRepository _repository;       

        public StudentRegisteredListService(IStudentRegisteredListRepository repository)
        {
            _repository = repository;      
        }

       
        public async Task<List<StudentRegisteredListdto>> GetStudentRegisteredListAsync(
            int collegeId,
            int facultyId,
            int examId
        )                      
        {
            var rawData = await _repository.GetExamStudentRawListAsync(
                collegeId, facultyId, examId);      
            
           
            return rawData.Select(item => new StudentRegisteredListdto
            {
                CollegeCode = item.CollegeCode ?? "",
                StudentName = item.StudentName,
                FatherName = item.FatherName,
                MotherName = item.MotherName,
                YearOfPassing = item.YearOfPassing
            }).ToList();
        }
    }
}