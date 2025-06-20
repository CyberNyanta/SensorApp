using GatewayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SensorApp.Data.Models;
using SensorApp.Data.Repositories;

namespace GatewayApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorClientController : ControllerBase
{
    // private readonly IHubContext<SensorHub> _hubContext;
    private readonly IMeasurementRepository  _measurementRepository;
    private readonly  ISensorRepository  _sensorRepository;
    
    private readonly ILogger<SensorClientController> _logger;

    public SensorClientController(
        ILogger<SensorClientController> logger, 
        // IHubContext<SensorHub> hubContext, 
        ISensorRepository sensorRepository, 
        IMeasurementRepository measurementRepository)
    {
        // _hubContext = hubContext;
        _measurementRepository = measurementRepository;
        _sensorRepository = sensorRepository;
        _logger = logger;
    }

    [HttpPost("UpdateMeasurement")]
    public async Task<IActionResult> UpdateMeasurement([FromBody] SensorMeasurmentModel data)
    {
        Console.WriteLine($"Received data from sensor {data.DeviceId}: {data.Measurment} = {data.Timestamp}");
        
        var sensor = await _sensorRepository.GetByIdAsync(data.DeviceId);

        if (sensor == null)
        {
            return NotFound();
        }

        await _measurementRepository.AddAsync(new MeasurementDto
        {
            DeviceId = data.DeviceId,
            Measurments = data.Measurment,
            Timestamp = data.Timestamp,
        });
        
        return Ok();
    }
    
    [HttpPut("RegisterDevice")]
    public async Task<IActionResult> RegisterDevice([FromBody] SensorDataModel data)
    {
        Console.WriteLine($"Received data from sensor {data.Created}: {data.SensorType} ");

        var sensor = new SensorDto
        {
            BuildingId = data.BuildingId,
            Floor = data.Floor,
            SensorType = data.SensorType,
            LastUpdated = data.Created
        };
        
        await _sensorRepository.AddAsync(sensor);

        return Ok(sensor);
    }
}