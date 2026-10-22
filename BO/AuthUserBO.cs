
namespace HSMS.API.BO
{
    public class AuthUserBO
    {
        public string UserId { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int? RoleId { get; set; }
        public string? Status { get; set; }
        public int? IsActive { get; set; }
    }
}
