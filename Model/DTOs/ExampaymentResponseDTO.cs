namespace APIExam.Model.DTOs
{
    public class ExampaymentResponseDTO
    {
        public int StudentID { get; set; }
        public string? RegistrationNo { get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public DateTime? DOB { get; set; }
        public string? CategoryName { get; set; }
        public string? Faculty { get; set; }
        public string? ExamTypeName { get; set; }
        public int? ExamTypeId { get; set; }
        public string? College { get; set; }
        public string? OfssReferenceNo { get; set; }
        public string? CollegeCode { get; set; }
        public bool? FormDownloaded { get; set; }
        public int? ConcessionFee { get; set; }
        public int? BaseFee { get; set; }
        public string? CasteCategoryCode { get; set; }
        public bool? IsFirstExam { get; set; }
       
    }
}
