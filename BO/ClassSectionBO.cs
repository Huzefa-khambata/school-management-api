namespace HSMS.API.BO
{
    public class ClassSectionBO
    {
        public int ClassSectionId { get; set; }

        public string? ClassCode { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public int? Strength { get; set; }
        public string? ClassTeacher { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}