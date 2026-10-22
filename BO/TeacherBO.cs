namespace HSMS.API.BO
{
    public class TeacherBO
    {
        public int TeacherId { get; set; }

        public string? UserId { get; set; }
        public string? Password { get; set; }

        public string? TeacherName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public string? EmployeeId { get; set; }
        public string? Qualification { get; set; }
        public string? Department { get; set; }
        public string? Status { get; set; }

        public string? Subject { get; set; }
        public string? AssignedClasses { get; set; }

        public string? Experience { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}