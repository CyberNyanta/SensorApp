namespace GatewayApi.Models;

public class SensorMeasurmentModel
{
    public int DeviceId { get; set; }
    public DateTime Timestamp { get; set; }
    public string Measurment { get; set; }
}