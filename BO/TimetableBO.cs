namespace HSMS.API.BO
{
    public class TimetableBO
    {
        public int TimetableId { get; set; }

        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? Day { get; set; }
        public int? Period { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? SubjectName { get; set; }
        public string? TeacherName { get; set; }
        public string? RoomNumber { get; set; }
        public int? TeacherId { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}