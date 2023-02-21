using Microsoft.AspNetCore.Mvc;

namespace CondominiumApi.Api.Controllers
{
    [ApiController]
    [Route("v1/vehicles")]
    public class VehicleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestesRetornos()
        {
            return Ok();
        }
    }
}