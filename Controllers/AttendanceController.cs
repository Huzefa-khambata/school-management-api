using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceRepository _attendanceRepository;

        public AttendanceController(AttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpGet]
        [Route("GetAttendanceList")]
        public IActionResult GetAttendanceList()
        {
            try
            {
                var result = _attendanceRepository.GetAttendanceList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}