using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SensorApp.Data.Repositories;

namespace SensorApp.Data;

public static class DataBuilderExtensions
{
    public static IServiceCollection UseDataServices(this IServiceCollection services, string connectionString)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(connectionString);

        var dbcontext = new SensorDbContext(connectionString);
        dbcontext.Database.EnsureDeleted();
        dbcontext.Database.EnsureCreated();
        dbcontext.SaveChanges();
        
        services.AddSingleton<SensorDbContext>(dbcontext);
        services.TryAddSingleton<IMeasurementRepository, MeasurementRepository>();
        services.TryAddSingleton<ISensorRepository, SensorRepository>();
        
        
        return services;
    }
}