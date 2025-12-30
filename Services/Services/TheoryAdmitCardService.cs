using APIExam.Model.DTOs;
using APIExam.Repositories;
using APIExam.Services.IServices;

namespace APIExam.Services.Services
{
    public class TheoryAdmitCardService : ITheoryAdmitCardService
    {
        private readonly ITheoryAdmitCardRepository _repository;

        public TheoryAdmitCardService(ITheoryAdmitCardRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TheoryAdmitCardDTO>> GetTheoryAdmitCardAsync(
            int collegeId, int facultyId, int examId)
        {
            return await _repository.GetTheoryAdmitCardAsync(
                collegeId, facultyId, examId);
        }
    }
}