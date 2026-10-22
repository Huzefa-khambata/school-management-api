using HSMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HSMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeController : ControllerBase
    {
        private readonly FeeRepository _feeRepository;

        public FeeController(FeeRepository feeRepository)
        {
            _feeRepository = feeRepository;
        }

        [HttpGet]
        [Route("GetFeeStructureList")]
        public IActionResult GetFeeStructureList()
        {
            try
            {
                var result = _feeRepository.GetFeeStructureList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet]
        [Route("GetFeeList")]
        public IActionResult GetFeeList()
        {
            try
            {
                var result = _feeRepository.GetFeeList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet]
        [Route("GetFeePaymentList")]
        public IActionResult GetFeePaymentList()
        {
            try
            {
                var result = _feeRepository.GetFeePaymentList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet]
        [Route("GetFeeReceiptList")]
        public IActionResult GetFeeReceiptList()
        {
            try
            {
                var result = _feeRepository.GetFeeReceiptList();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}