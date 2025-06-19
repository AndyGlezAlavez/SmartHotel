using SmartHotel.Contracts.Repositories;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Contracts;
using SmartHotel.Persistence.Contexts;

namespace SmartHotel.Persistence.Repositories.Managers
{

    public class AppRepositoryManager
        : IAppRepositoryManager
    {
        //public AppRepositoryManager(AppDbContext context);
        public AppRepositoryManager(AppDbContext context) { }
        public IRoomRepository Room { get; }
        public IVariableRepository Variable { get; }
        public ISmokeRepository Smoke { get; }
        public ITemperatureRepository Temperature { get; }
        public ILightRepository Light { get; }
        public IUnitOfWork UnitOfWork { get; }

        public IAgreementRepository Agreement { get; }
    }
}

