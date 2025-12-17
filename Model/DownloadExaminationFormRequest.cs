namespace APIExam.Model
{
    public class DownloadExaminationFormRequest
    {
        public List<int> StudentIds { get; set; } = new();
        public int CollegeId { get; set; }  
        public int FacultyId { get; set; }  
        public int ExamTypeId { get; set; }  
    }
}
