using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GetFetchController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // Hier kannst du die Logik für die Verarbeitung der GET-Anforderung einfügen
        // Zum Beispiel: Daten abrufen und zurückgeben

       return Ok(new { Message = "GET-Anfrage auf /getfetch erfolgreich verarbeitet." });
    }
}
