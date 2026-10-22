
namespace HSMS.API.BO
{
    public class AddUserBO
    {
        public string UserId { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}
