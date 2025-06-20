namespace SensorApp.Data.Models;

public class MeasurementDto
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public string Measurments { get; set; }
    public DateTime Timestamp { get; set; }
}