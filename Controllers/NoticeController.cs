using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticeController : ControllerBase
    {
        private readonly NoticeRepository _noticeRepository;

        public NoticeController(NoticeRepository noticeRepository)
        {
            _noticeRepository = noticeRepository;
        }

        [HttpGet]
        [Route("GetNoticeList")]
        public IActionResult GetNoticeList()
        {
            try
            {
                var result = _noticeRepository.GetNoticeList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}