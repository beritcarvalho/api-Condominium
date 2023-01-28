using CondominiumApi.Applications.Dtos.InputModels;
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

        [HttpGet]
        public async Task<IActionResult> GetAllApartments()
        {
            try
            {
                var apartments = await _apartmentService.GetAll();

                if (apartments == null)
                    return NotFound("Não foi encontrado nenhum apartamento");

                return Ok(apartments);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetApartmentById([FromRoute] int id)
        {
            var apartment = await _apartmentService.GetByIdWithInclude(id);
            return Ok(apartment);
        }

        [HttpPost("newApartment")]
        public async Task<IActionResult> InsertApartment([FromBody] ApartmentInputModel newApartment)
        {
            var apartment = await _apartmentService.InsertNewApartment(newApartment);
            return Ok(apartment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApartmentData([FromBody] ApartmentInputModel newApartment)
        {
            var apartment = await _apartmentService.UpdateApartment(newApartment);

            return Ok(apartment);
        }



        [HttpPut("ResetData")]
        public async Task<IActionResult> ResetApartmentData([FromBody] ApartmentInputModel newApartment)
        {
            var apartment = await _apartmentService.ResetApartmentData(newApartment);

            return Ok(apartment);
        }        
    }
}
