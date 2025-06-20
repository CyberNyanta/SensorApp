using Microsoft.AspNetCore.Mvc;

namespace GatewayAdmin.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorAdminController : ControllerBase
{
    private readonly ILogger<SensorAdminController> _logger;

    public SensorAdminController(ILogger<SensorAdminController> logger)
    {
        _logger = logger;
    }

 
    // [HttpPost("ping")]
    // public async Task<IActionResult> PingSensor([FromBody] PingRequestModel request)
    // {
    //     // todo 
    //     // await _hubContext.Clients.All.SendAsync("ForceUpdate", request);
    //     return Ok("Ping sent to all sensors.");
    // }
}