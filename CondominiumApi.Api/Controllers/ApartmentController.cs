using Microsoft.AspNetCore.Mvc;

namespace CondominiumApi.Api.Controllers
{
    [ApiController]
    [Route("v1/apartments")]
    public class ApartmentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Teste()
        {
            return Ok();
        }
    }
}
