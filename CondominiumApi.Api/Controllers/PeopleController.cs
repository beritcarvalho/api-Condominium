using CondominiumApi.Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondominiumApi.Api.Controllers
{
    [ApiController]
    [Route("v1/people")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok();
        }
    }
}
