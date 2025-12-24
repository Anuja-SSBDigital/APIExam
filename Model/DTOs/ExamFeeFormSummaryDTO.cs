using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIExam.Model.DTOs
{
    [Keyless]
    public class ExamFeeFormSummaryDTO
    {
       

        [Column("Faculty")]
        public string? Faculty { get; set; }

       
        [Column("Exam Type")]
        public string? ExamType { get; set; }

        
        [Column("Fee Submitted")]
        public int FeeSubmitted { get; set; }

        
        [Column("Form Submitted")]
        public int FormSubmitted { get; set; }


        [Column("Form Not Submitted")]
        public int FormNotSubmitted { get; set; }
    }
}