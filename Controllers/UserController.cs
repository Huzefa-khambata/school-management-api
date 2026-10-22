using HSMS.API.BO;
using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetUserList")]
        public IActionResult GetUserList()
        {
            try
            {
                var result = _userRepository.GetUserList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }


        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] AddUserBO user)
        {
            try
            {
                var result = _userRepository.AddUser(user);

                return Ok(new { result = result });
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

    }
}