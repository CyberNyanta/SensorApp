using SensorApp.Data.Models;

namespace SensorApp.Data.Repositories;

public interface ISensorRepository
{
    Task<IEnumerable<SensorDto>> GetAllAsync();
    Task<SensorDto?> GetByIdAsync(int id);
    Task<SensorDto?> AddAsync(SensorDto sensor);
    Task UpdateAsync(SensorDto sensor);
    Task DeleteAsync(int id);
}