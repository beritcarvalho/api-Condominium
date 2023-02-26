using CondominiumApi.Applications.Dtos.InputModels;
using CondominiumApi.Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondominiumApi.Api.Controllers
{
    [ApiController]
    [Route("v1/vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var list = await _vehicleService.GetAllVehicles();
            return Ok(list);
        }

        [HttpGet("{id:decimal}")]
        public async Task<IActionResult> GetVehicle([FromRoute]decimal? id)
        {
            var vehicle = await _vehicleService.GetVehicle(id, null);
            return Ok(vehicle);
        }

        [HttpGet("{plate}")]
        public async Task<IActionResult> GetVehicle([FromRoute] string plate)
        {
            var vehicle = await _vehicleService.GetVehicle(null, plate);
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewVehicle([FromBody] VehicleInputModel newVehicle)
        {
            var vehicle = await _vehicleService.AddVehicle(newVehicle);
            return Ok(vehicle);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] VehicleInputModel currentVehicleData)
        {
            var vehicle = await _vehicleService.UpdateVehicle(currentVehicleData);
            return Ok(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModels()
        {
            var list = await _vehicleService.GetAllVehicles();
            return Ok(list);
        }
    }
}