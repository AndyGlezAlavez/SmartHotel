using SmartHotel.Contracts.Repositories;
using SmartHotel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Persistence.Repositories
{
    public class AgreementRepository
        : IAgreementRepository
    {

        private readonly AppDbContext _context;

        public AgreementRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async void DeleteById(Guid id)
        {
            var agreementRepository = await _context.Agreements.FindAsync(id);
            if (agreementRepository is null)
                return;
            _context.Agreements.Remove(agreementRepository);
        }
        public Task<IEnumerable<Agreement>> GetAgreementsAsync()
        {
            return Task.FromResult<IEnumerable<Agreement>>(_context.Agreements.ToList());
        }

        public async Task AddAsync(Agreement agreement)
        {
            await _context.Agreements.AddAsync(agreement);
        }

        async Task<Agreement> IAgreementRepository.GetAgreementsByIdAsync(Guid id)
        {
            return (await _context.Agreements.FindAsync(id))!;
        }

        async Task<IEnumerable<Agreement>> IAgreementRepository.GetAgreementsByUnitAsync(Guid roomId)
        {
           return await _context.Agreements.Where(a => a.RoomId == roomId).ToListAsync();
        }

        public void Update(Agreement agreement)
        {
            _context.Update(agreement);
        }
    }
}
