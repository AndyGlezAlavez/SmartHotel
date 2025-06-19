using SmartHotel.Contracts.Repositories;
using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace SmartHotel.Persistence.Repositories
{
    public class SmokeRepository
        : ISmokeRepository
    {

        private readonly AppDbContext _context;

        public SmokeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Smoke smoke)
        {
            await _context.Variables.AddAsync(smoke);
        }

        public async void DeleteById(Guid id)
        {
            var smoke = await _context.Smokes.FindAsync(id);
            if (smoke is null)
                return;
            _context.Variables.Remove(smoke);
        }

        public async Task<Smoke> GetByIdAsync(Guid id)
        {
            return (await _context.Smokes.FindAsync(id))!;
        }

        public Task<IEnumerable<Smoke>> GetSmokesAsync()
        {
            return Task.FromResult<IEnumerable<Smoke>>(_context.Smokes.ToList());
        }

        public void Update(Smoke smoke)
        {
            _context.Smokes.Update(smoke);
        }
    }
}