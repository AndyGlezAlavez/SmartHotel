using SmartHotel.Contracts.Repositories;
using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace SmartHotel.Persistence.Repositories
{
    public class TemperatureRepository
        : ITemperatureRepository
    {

        private readonly AppDbContext _context;

        public TemperatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Temperature temperature)
        {
            await _context.Temperatures.AddAsync(temperature);
        }

        public async void DeleteById(Guid id)
        {
            var temperature = await _context.Temperatures.FindAsync(id);
            if (temperature is null)
                return;
            _context.Temperatures.Remove(temperature);
        }

        public async Task<Temperature> GetByIdAsync(Guid id)
        {
            return (await _context.Temperatures.FindAsync(id))!;
        }
        
        public Task<IEnumerable<Temperature>> GetTemperaturesAsync()
        {
            return Task.FromResult<IEnumerable<Temperature>>(_context.Temperatures.ToList());
        }

        public void Update(Temperature temperature)
        {
            _context.Temperatures.Update(temperature);
        }
    }
}