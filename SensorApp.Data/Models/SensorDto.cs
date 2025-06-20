namespace SensorApp.Data.Models;

public class SensorDto
{
    public int Id { get; set; }
    public int? BuildingId { get; set; }
    public int? Floor { get; set; }
    
    public string? LastValue { get; set; }
    public DateTime? LastUpdated { get; set; }
    public SensorType SensorType { get; set; }
}