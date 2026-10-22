using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimetableController : ControllerBase
    {
        private readonly TimetableRepository _timetableRepository;

        public TimetableController(TimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }

        [HttpGet]
        [Route("GetTimetableList")]
        public IActionResult GetTimetableList()
        {
            try
            {
                var result = _timetableRepository.GetTimetableList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}