namespace HSMS.API.BO
{
    public class ExaminationBO
    {
        public int ExaminationId { get; set; }

        public string? ExamCode { get; set; }
        public string? ExamName { get; set; }
        public string? ExamType { get; set; }
        public string? ClassName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxMarks { get; set; }
        public string? Status { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}