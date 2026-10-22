
using HSMS.API.BO;
using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(AuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequestBO request)
        {
            try
            {
                var user = _authRepository.GetUserForLogin(request.UserId);

                if (user == null ||
                    string.IsNullOrWhiteSpace(user.PasswordHash) ||
                    !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    return Unauthorized("Invalid user ID or password.");
                }

                if (user.IsActive != 1 ||
                    !string.Equals(user.Status, "Active", StringComparison.OrdinalIgnoreCase))
                {
                    return Unauthorized("User account is inactive.");
                }

                var jwtKey = _configuration["Jwt:Key"];

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId),
                    new Claim(ClaimTypes.Role, user.RoleId?.ToString() ?? "")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!));

                var credentials = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(2),
                    signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    message = "Login successful.",
                    token = tokenString,
                    user = new
                    {
                        userId = user.UserId,
                        roleId = user.RoleId
                    }
                });
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}
