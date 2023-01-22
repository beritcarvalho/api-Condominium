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
        public async Task<IActionResult> GetAllPeople() 
        {
            var people = await _personService.GetAll();
            return Ok(people);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPersonById([FromRoute] Guid id)
        {
            var person = await _personService.GetById(id);
            return Ok(person);
        }
    }
}
