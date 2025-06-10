using SmartHotel.Contracts.Repositories;
using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace SmartHotel.Persistence.Repositories
{
    public class LightRepository
        : ILightRepository
    {

        private readonly AppDbContext _context;

        public LightRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Light light)
        {
            await _context.Lights.AddAsync(light);
        }

        public async void DeleteById(Guid id)
        {
            var light = await _context.Lights.FindAsync(id);
            if (light is null)
                return;
            _context.Lights.Remove(light);
        }

        public async Task<Light?> GetByIdAsync(Guid id)
        {
            return await _context.Lights.FindAsync(id);
        }

        public Task<IEnumerable<Light>> GetLightsAsync()
        {
            return Task.FromResult<IEnumerable<Light>>(_context.Lights.ToList());
        }

        public void Update(Light light)
        {
            _context.Lights.Update(light);
        }
    }
}