using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassSectionController : ControllerBase
    {
        private readonly ClassSectionRepository _classSectionRepository;

        public ClassSectionController(ClassSectionRepository classSectionRepository)
        {
            _classSectionRepository = classSectionRepository;
        }

        [HttpGet]
        [Route("GetClassSectionList")]
        public IActionResult GetClassSectionList()
        {
            try
            {
                var result = _classSectionRepository.GetClassSectionList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}