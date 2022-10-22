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
    }
}
