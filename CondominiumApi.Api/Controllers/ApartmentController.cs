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

                if (apartments is null)
                    return NotFound(new ResultViewModel<ApartmentViewModel>("ERR-APCX01 Não foi encontrado nenhum apartamento"));

                return Ok(new ResultViewModel<List<ApartmentViewModel>>(apartments));
            }
            catch(Exception exception)
            {
                return StatusCode(500, new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetApartmentById([FromRoute] int id)
        {
            try
            {
                var apartment = await _apartmentService.GetByIdWithInclusions(id);

                if(apartment is null)
                {
                    return NotFound(new ResultViewModel<ApartmentViewModel>("ERR-APCX01 Apartamento não encontrado"));
                }

                return Ok(new ResultViewModel<ApartmentViewModel>(apartment));
            }
            catch(Exception exception)
            {
                return StatusCode(500, new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertApartment([FromBody] ApartmentInputModel newApartment)
        {
            try
            {
                var apartment = await _apartmentService.InsertNewApartment(newApartment);
                return Created($"/newApartment/{apartment.Id}", new ResultViewModel<ApartmentViewModel>(apartment));
            }
            catch(ValidationException exception)
            {
                return BadRequest(new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
            catch (NotFoundException exception)
            {
                return NotFound(new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApartmentData([FromBody] ApartmentInputModel newApartment)
        {
            try
            {
                var apartment = await _apartmentService.UpdateApartment(newApartment);

                return Ok(new ResultViewModel<ApartmentViewModel>(apartment));
            }
            catch(NotFoundException exception)
            {
                return NotFound(new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
            catch (ValidationException exception)
            {
                return BadRequest(new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
        }

        [HttpPut("reset")]
        public async Task<IActionResult> ResetApartmentData([FromBody] ApartmentInputModel newApartment)
        {
            try
            {
                var apartment = await _apartmentService.ResetApartmentData(newApartment);

                return Ok(new ResultViewModel<ApartmentViewModel>(apartment));
            }
            catch (NotFoundException exception)
            {
                return NotFound(new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
            catch (ValidationException exception)
            {
                return BadRequest(new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ResultViewModel<ApartmentViewModel>(exception.Message));
            }
        }        
    }
}
