namespace HSMS.API.Model
{
    public class TeacherModel
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
    }
}