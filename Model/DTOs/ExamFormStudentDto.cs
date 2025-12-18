using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable

namespace APIExam.Model.DTOs
{
    [Keyless]
    public class ExamFormStudentDto
    {

        public string CollegeCode { get; set; }                     
        public string RegistrationNo { get; set; }
        public string StudentName { get; set; }
        public bool IsRegFeeSubmit { get; set; }
        public bool IsRegFormSubmit { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string YearOfPassing { get; set; }
        public string CategoryName { get; set; }
        public string Faculty { get; set; }
        public int StudentID { get; set; }
        public string TransactionId { get; set; }
        public bool IsExamFeeSubmit { get; set; }
        public bool IsExamFormSubmit { get; set; }
        public int? ExamTypeid { get; set; } 
        public string CorrectionRemarks { get; set; }

      
        [NotMapped]
        public string Status { get; set; }
        [NotMapped]
        public int StatusOrder { get; set; }

    }
}