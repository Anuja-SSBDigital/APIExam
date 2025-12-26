using Microsoft.EntityFrameworkCore;

namespace APIExam.Model.DTOs
{
    [Keyless]
    public class ExamPaymentStatusDTO
    {
        public int Pk_PaymentId { get; set; }
        public int Fk_CollegeId { get; set; }
        public int Fk_FeeTypeId { get; set; }

        public string? BankGateway { get; set; }
        public string? PaymentMode { get; set; }

        public decimal? PaymentAmount { get; set; }
        public decimal? AmountPaid { get; set; }

        public string? ClientTxnId { get; set; }
        public string? GatewayTxnId { get; set; }
        public string? BankTxnId { get; set; }

        public string? PaymentStatus { get; set; }
        public string? PaymentStatusCode { get; set; }

        public DateTime? PaymentInitiateDate { get; set; }
        public DateTime? PaymentUpdatedDate { get; set; }
        public DateTime? PaymentCreatedOn { get; set; }

        public int? StudentsPerTransaction { get; set; }

        public string? CollegeName { get; set; }
        public string? CollegeCode { get; set; }
    }
}
