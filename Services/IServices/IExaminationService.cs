using APIExam.Model;
using APIExam.Model.DTOs;

namespace APIExam.Services.IServices
{
    public interface IExaminationService
    {
        Task<List<DownloadExamFormResponse>> DownloadExamFormAsync(DownloadExaminationFormRequest examinationFormRequest);
    }
}
