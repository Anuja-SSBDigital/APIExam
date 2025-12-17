using System.ComponentModel.DataAnnotations;

namespace APIExam.Model
{
    public class DonwloadExamformModel
    {
        public int CollegeId { get; set; }
        public string? StudentName { get; set; }
        public int FacultyId { get; set; }
        public int? ExamId { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategory { get; set; }
    }


    public class Student_Mst
    {
        [Key]
        public int StudentID { get; set; }
        public int CollegeId { get; set; }
    
        public string? College { get; set; }
        public string CollegeCode { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? ExamTypeName { get; set; }
        public int? ExamTypeId { get; set; }
        public string? Faculty { get; set; }
        public int? FacultyId { get; set; }
       
        public DateTime? DOB { get; set; }
        public bool? FormDownloaded { get; set; }
    }
}
