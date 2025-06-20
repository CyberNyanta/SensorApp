using SensorApp.Data.Models;

namespace SensorApp.Data.Repositories;

public interface IMeasurementRepository
{
    Task<IEnumerable<MeasurementDto>> GetAllAsync();
    Task<MeasurementDto?> GetByIdAsync(int id);
    Task AddAsync(MeasurementDto measurement);
    Task UpdateAsync(MeasurementDto measurement);
    Task DeleteAsync(int id);
}