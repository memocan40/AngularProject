using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetDataController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GET-Anfrage erfolgreich verarbeitet");
        }
    }
}
