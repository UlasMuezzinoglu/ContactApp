using Business.Abstract;
using Entity.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            this._personService = personService;
        }

        [HttpPost("add")]
        public IActionResult Get([FromQuery] CreatePersonRequest createPersonRequest)
        {
            var result = _personService.Add(createPersonRequest);

            return Ok(result);
        }

    }
}
