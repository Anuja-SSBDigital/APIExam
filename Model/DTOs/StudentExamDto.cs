namespace APIExam.Model.DTOs

#pragma warning disable
{
    public class StudentExamDto
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public bool IsExamFeeSubmit { get; set; }
        public bool IsExamFormSubmit { get; set; }

        public string Status { get; set; }
        public int StatusOrder { get; set; }
    }
}
