namespace HSMS.API.BO
{
    public class FeePaymentBO
    {
        public int FeePaymentId { get; set; }
        public int? FeeId { get; set; }
        public int? StudentId { get; set; }

        public string? AdmissionNumber { get; set; }
        public string? StudentName { get; set; }

        public string? FeeHead { get; set; }
        public int? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentMode { get; set; }
        public string? TransactionNumber { get; set; }
        public string? Remarks { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}