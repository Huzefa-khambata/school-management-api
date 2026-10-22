namespace HSMS.API.BO
{
    public class FeeStructureBO
    {
        public int FeeStructureId { get; set; }
        public string? AcademicYear { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? FeeHead { get; set; }
        public int? Amount { get; set; }
        public DateTime? DueDate { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}