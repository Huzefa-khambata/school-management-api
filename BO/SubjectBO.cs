namespace HSMS.API.BO
{
    public class SubjectBO
    {
        public int SubjectId { get; set; }

        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public string? AssignedTeacher { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}