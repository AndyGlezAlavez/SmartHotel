using SmartHotel.Contracts.Repositories;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Contracts;
using SmartHotel.Persistence.Repositories;
using SmartHotel.Persistence.Repositories.Managers;
using SmartHotel.Persistence.Contexts;

namespace SmartHotel.Persistence.Repositories.Managers
{
    public class AppRepositoryManager
        : IAppRepositoryManager
    {
        private readonly AppDbContext _context;

        private IVariableRepository? _variable = null;
        public IVariableRepository Variable
        {
            get
            {
                _variable ??= new VariableRepository(_context);
                return _variable;
            }
        }
        private ISmokeRepository? _smoke = null;
        public ISmokeRepository Smoke
        {
            get
            {
                _smoke ??= new SmokeRepository(_context);
                return _smoke;
            }
        }

        private ITemperatureRepository? _temperature = null;
        public ITemperatureRepository Temperature
        {
            get
            {
                _temperature ??= new TemperatureRepository(_context);
                return _temperature;
            }
        }

        private ILightRepository? _light = null;
        public ILightRepository Light
        {
            get
            {
                _light ??= new LightRepository(_context);
                return _light;
            }
        }

        private IRoomRepository? _room = null;
        public IRoomRepository Room
        {
            get
            {
                _room ??= new RoomRepository(_context);
                return _room;
            }
        }

        private IAgreementRepository? _agreement = null;
        public IAgreementRepository Agreement
        {
            get
            {
                _agreement ??= new AgreementRepository(_context);
                return _agreement;
            }
        }

        public AppRepositoryManager(AppDbContext context)
        {
            _context = context;
        }
        private IUnitOfWork? _unitOfWork = null;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                _unitOfWork ??= new UnitOfWork(_context);
                return _unitOfWork;
            }
        }
    }
}

