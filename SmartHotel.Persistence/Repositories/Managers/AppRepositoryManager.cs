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
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        public AppRepositoryManager(AppDbContext context)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        {
            Context = context;
            Agreement = new AgreementRepository(context);
            UnitOfWork = new UnitOfWork(context);
        }

        private IRoomRepository? _rooms = null;
        public IRoomRepository Room { get 
            { 
                if(_rooms is not null)
                    return _rooms;
                _rooms = new RoomRepository(Context);
                return _rooms;
            } 
        }
        public IVariableRepository Variable { get; }
        public ISmokeRepository Smoke { get; }
        public ITemperatureRepository Temperature { get; }
        public ILightRepository Light { get; }
        public IUnitOfWork UnitOfWork { get; }

        public IAgreementRepository Agreement { get; }
        private readonly AppDbContext Context;
    }
}

