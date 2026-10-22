namespace HSMS.API.BO
{
    public class AttendanceBO
    {
        public int AttendanceId { get; set; }

        public int? StudentId { get; set; }
        public string? AdmissionNumber { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public string? AttendanceStatus { get; set; }
        public string? Remarks { get; set; }

        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}