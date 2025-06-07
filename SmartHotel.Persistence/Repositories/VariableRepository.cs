using SmartHotel.Contracts.Repositories;
using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace SmartHotel.Persistence.Repositories
{
    public class VariableRepository
        : IVariableRepository
    {

        private readonly AppDbContext _context;

        public VariableRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Variable variable)
        {
            await _context.Variables.AddAsync(variable);
        }

        public async void DeleteById(Guid id)
        {
            var variable = await _context.Variables.FindAsync(id);
            if (variable is null)
                return;
            _context.Variables.Remove(variable);
        }

        public async Task<Variable?> GetByIdAsync(Guid id)
        {
            return await _context.Variables.FindAsync(id);
        }

        public Task<IEnumerable<Variable>> GetVariablesAsync()
        {
            return Task.FromResult<IEnumerable<Variable>>(_context.Variables.ToList());
        }

        public void Update(Variable variable)
        {
            _context.Variables.Update(variable);
        }
    }
}
