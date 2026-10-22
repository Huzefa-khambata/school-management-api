namespace HSMS.API.BO
{
    public class FeeBO
    {
        public int FeeId { get; set; }
        public int? StudentId { get; set; }
        public string? AdmissionNumber { get; set; }
        public string? StudentName { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }

        public int? TotalFee { get; set; }
        public int? Paid { get; set; }
        public int? LateFee { get; set; }
        public int? Balance { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}