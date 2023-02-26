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
            var vehicles = await _vehicleService.GetAllVehicles();
            return Ok(vehicles);
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

        [HttpGet("models")]
        public async Task<IActionResult> GetAllModels()
        {
            var models = await _vehicleService.GetAllModels();
            return Ok(models);
        }

        [HttpGet("models/{id:int}")]
        public async Task<IActionResult> GetModel([FromRoute] int id)
        {
            var model = await _vehicleService.GetModel(id);
            return Ok(model);
        }

        [HttpPost("models")]
        public async Task<IActionResult> AddNewVehicleModel([FromBody] VehicleModelInputModel newModel)
        {
            var model = await _vehicleService.AddModel(newModel);
            return Ok(model);
        }

        [HttpPut("models")]
        public async Task<IActionResult> UpdateModel([FromBody] VehicleModelInputModel currentModelData)
        {
            var model = await _vehicleService.UpdateModel(currentModelData);
            return Ok(model);
        }

    }
}