using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Dtos.ViewModels;
using CondominiumApi.Applications.Interfaces;
using CondominiumApi.Domain.Exceptions;
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
                    return NotFound("ERR-APCX01 Não foi encontrado nenhum apartamento");

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
            try
            {
                var apartment = await _apartmentService.GetByIdWithInclude(id);

                if(apartment == null)
                {
                    return NotFound("ERR-APCX01 Apartamento encontrado");
                }

                return Ok(apartment);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPost("newApartment")]
        public async Task<IActionResult> InsertApartment([FromBody] ApartmentInputModel newApartment)
        {
            try
            {
                var apartment = await _apartmentService.InsertNewApartment(newApartment);
                return Ok(apartment);
            }
            catch(ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApartmentData([FromBody] ApartmentInputModel newApartment)
        {
            try
            {
                var apartment = await _apartmentService.UpdateApartment(newApartment);

                return Ok(apartment);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }



        [HttpPut("ResetData")]
        public async Task<IActionResult> ResetApartmentData([FromBody] ApartmentInputModel newApartment)
        {
            var apartment = await _apartmentService.ResetApartmentData(newApartment);

            return Ok(apartment);
        }        
    }
}
