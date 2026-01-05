using APIExam.Model.DTOs;
using APIExam.Repositories;
using APIExam.Services.IServices;

namespace APIExam.Services.Services
{
    public class DummyExamAdmitcardService:IDummyExamAdmitcardService
    {
        private readonly IDummyExamAdmitcardRepository _repository;


        public DummyExamAdmitcardService(IDummyExamAdmitcardRepository repository)
        {
            _repository = repository;
        }



        public async Task<List<DummyExamAdmitcarddto>> GetdummyAdmitCardAsync(
            int collegeId, int facultyId, int examId)
        {
            return await _repository.GetdummyAdmitCardAsync(
                collegeId, facultyId, examId);
        }
    }
}
