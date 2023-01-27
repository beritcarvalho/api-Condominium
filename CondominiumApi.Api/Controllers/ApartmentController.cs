using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondominiumApi.Api.Controllers
{
    [ApiController]
    [Route("v1/apartments")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAccountId([FromRoute] int id)
        {
            var apartment = await _apartmentService.GetByIdWithInclude(id);
            return Ok(apartment);
        }
    }
}
