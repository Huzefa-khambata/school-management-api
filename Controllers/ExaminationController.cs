using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExaminationController : ControllerBase
    {
        private readonly ExaminationRepository _examinationRepository;

        public ExaminationController(ExaminationRepository examinationRepository)
        {
            _examinationRepository = examinationRepository;
        }

        [HttpGet]
        [Route("GetExaminationList")]
        public IActionResult GetExaminationList()
        {
            try
            {
                var result = _examinationRepository.GetExaminationList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}