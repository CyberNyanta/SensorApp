using SensorApp.Data.Models;

namespace GatewayApi.Models;

public class SensorDataModel
{
    public int BuildingId { get; set; }
    public int Floor { get; set; }
    public DateTime Created { get; set; }
    public SensorType SensorType { get; set; }
}