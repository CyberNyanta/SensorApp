using SensorApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SensorApp.Data.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly SensorDbContext _context;

        public MeasurementRepository(SensorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MeasurementDto>> GetAllAsync()
        {
            return await _context.Measurement.ToListAsync();
        }

        public async Task<MeasurementDto?> GetByIdAsync(int id)
        {
            return await _context.Measurement.FindAsync(id);
        }

        public async Task AddAsync(MeasurementDto measurement)
        {
            await _context.Measurement.AddAsync(measurement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MeasurementDto measurement)
        {
            _context.Measurement.Update(measurement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var measurement = await _context.Measurement.FindAsync(id);
            if (measurement != null)
            {
                _context.Measurement.Remove(measurement);
                await _context.SaveChangesAsync();
            }
        }
    }
}