using APIExam.Model;

namespace APIExam.Services.IServices
{
    public interface IDwnldExmFrmService
    {
        Task<List<Student_Mst>> DownloadExamFormAsync(DonwloadExamformModel donwloadExamformModel);
    }
}
