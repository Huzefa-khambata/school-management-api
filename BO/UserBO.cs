namespace HSMS.API.BO
{
    public class UserBO
    {
        public string? UserId { get; set; }
        public string? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Status { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LmodBy { get; set; }
        public DateTime? LmodOn { get; set; }
        public int? IsActive { get; set; }
    }
}