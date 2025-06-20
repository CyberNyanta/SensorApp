using Microsoft.EntityFrameworkCore;
using SensorApp.Data.Models;

namespace SensorApp.Data;

public class SensorDbContext: DbContext
{
    private string connectionString;

    public SensorDbContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public DbSet<SensorDto> Sensors { get; set; }
    public DbSet<MeasurementDto> Measurement { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(connectionString);
}