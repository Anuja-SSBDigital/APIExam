using APIExam.Model.DTOs;
using APIExam.Repositories;
using APIExam.Services.IServices;

namespace APIExam.Services.Services
{
    public class PracticalAdmitCardService : IPracticalAdmitCardService
    {
        private readonly IPracticalAdmitCardRepository _repository;

        public PracticalAdmitCardService(IPracticalAdmitCardRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PracticalAdmitCardDTO>> GetPracticalAdmitCardAsync(
            int collegeId, int facultyId, int examId)
        {
            return await _repository.GetPracticalAdmitCardAsync(
                collegeId, facultyId, examId);
        }
    }
}