using Business.Abstract;
using Business.Concrete;
using Entity.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactModelsController : ControllerBase
    {
        IContactModelService _contactModelService;

        public ContactModelsController(IContactModelService contactModelService)
        {
            _contactModelService = contactModelService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromQuery] CreateContactModelRequest createContactModelRequest)
        {
            var result = _contactModelService.Add(createContactModelRequest);

            return Ok(result);
        }

        [HttpGet("GetTotalContactByLocation")]
        public IActionResult GetTotalContactByLocation([FromQuery] string location)
        {
            var result = _contactModelService.GetTotalContactByLocation(location);

            return Ok(result);
        }

        [HttpGet("GetTotalGsmCountByLocation")]
        public IActionResult GetTotalGsmCountByLocation([FromQuery] string location)
        {
            var result = _contactModelService.GetTotalGsmCountByLocation(location);

            return Ok(result);
        }
        

        [HttpGet("GetAllReportTypes")]
        public IActionResult GetAllReportTypes([FromQuery] string location)
        {
            var result = _contactModelService.GetAllReportTypes(location);

            return Ok(result);
        }
    }
}
