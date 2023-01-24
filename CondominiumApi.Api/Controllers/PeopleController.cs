using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

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
            try
            {
                var people = await _personService.GetAll();

                if (people == null)
                    return NotFound(new ResultViewModel<IList<PersonViewModel>>("Nenhum cadastro encontrado"));
                
                return Ok(new ResultViewModel<IList<PersonViewModel>>(people));
            }
            catch(Exception exception) 
            {               
                return StatusCode(500, new ResultViewModel<List<PersonViewModel>>(exception.Message));
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPersonById([FromRoute] Guid id)
        {
            var person = await _personService.GetById(id);

            if (person == null)
                return NotFound(new ResultViewModel<PersonViewModel>("Cadastro não encontrado"));

            return Ok(new ResultViewModel<PersonViewModel>(person));
        }

        [HttpPost("/newperson")]
        public async Task<IActionResult> RegisterNewPerson([FromBody] PersonInputModel newPerson)
        {
            var person = await _personService.AddPerson(newPerson);
            return Created($"/newperson/{person.Id}", new ResultViewModel<PersonViewModel>(person));            
        }

        [HttpGet("/guid")]
        public async Task<IActionResult> GetNewGuid()
        {
            var guid = Guid.NewGuid();   

            return Ok(new ResultViewModel<Guid>(guid));
        }
    }
}
