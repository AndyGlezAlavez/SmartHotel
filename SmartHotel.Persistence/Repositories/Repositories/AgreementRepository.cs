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

        public async Task AddAsync(AgreementRepository agreementRepository)
        {
            await _context.AgreementRepository.AddAsync(agreementRepository);
        }

        public async Task<IEnumerable<AgreementRepository>> GetEquipmentStateChangeRecords(DateTime start, DateTime end)
        {
            return await _context.AgreementRepository
                .Where(x => x.OccurringTime >= start && x.OccurringTime <= end)
                .ToListAsync();
        }
        public async Task<IEnumerable<AgreementRepository> GetAgreementRepositoryByUnitAsync(Guid Id)
        {
            var agreementRepository = await _context.Agreements.Include(u => u.agreementRepository).FirstAsync(u => u.Id == Id);
            return agreementRepository.AgreementRepository;
        }

        public async Task<AgreementRepository> GetByIdAsync(Guid id)
        {
            return await _context.Agreements.FindAsync(id);
        }

        public void Update(AgreementRepository agreementRepository)
        {
            _context.Update(agreementRepository);
        }
        public async void DeleteById(Guid id)
        {
            var agreementRepository = await _context.AgreementRepository.FindAsync(id);
            if (agreementRepository is null)
                return;
            _context.Agrements.Remove(Agreement);
        }
    }
}
