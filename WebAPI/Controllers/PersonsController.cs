using Business.Abstract;
using Entity.DTOs.Request;
using Entity.DTOs.Request.Common;
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
        public IActionResult Add([FromQuery] CreatePersonRequest createPersonRequest)
        {
            var result = _personService.Add(createPersonRequest);

            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromQuery] ByIdRequest byIdRequest)
        {
            var result = _personService.Delete(byIdRequest);

            return Ok(result);
        }

    }
}
