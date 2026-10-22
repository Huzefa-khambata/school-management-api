namespace HSMS.API.BO
{
    public class FeeReceiptBO
    {
        public int FeeReceiptId { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? StudentName { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? FeeHead { get; set; }
        public int? Amount { get; set; }
        public string? PaymentMode { get; set; }
        public DateTime? PaymentDate { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}