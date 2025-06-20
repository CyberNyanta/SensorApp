using Microsoft.EntityFrameworkCore;
using SensorApp.Data.Models;

namespace SensorApp.Data.Repositories;

public class SensorRepository : ISensorRepository
{
        private readonly SensorDbContext _context;

        public SensorRepository(SensorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SensorDto>> GetAllAsync()
        {
            return await _context.Sensors.ToListAsync();
        }

        public async Task<SensorDto?> GetByIdAsync(int id)
        {
            return await _context.Sensors.FindAsync(id);
        }

        public async Task<SensorDto?> AddAsync(SensorDto sensor)
        {
            var newEntry = await _context.Sensors.AddAsync(sensor);
            await _context.SaveChangesAsync();
            return newEntry.Entity;
        }

        public async Task UpdateAsync(SensorDto sensor)
        {
            _context.Sensors.Update(sensor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensors.Remove(sensor);
                await _context.SaveChangesAsync();
            }
        }
}