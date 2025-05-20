using SmartHotel.Contexts;
using SmartHotel.Persistence.Repositories;
using SmartHotel.Persistence.Managers;
using SmartHotel.Persistence.Contexts;

namespace SmartHotel.Persistence.Repositories.Managers
{
    public class AppRepositoryManager
        : IAppRepositoryManager
    {
        private readonly AppDbContext _context;

        private ILightRepository? _lihght = null;
        public ILightRepository Light
        {
            get
            {
                if (_light is null)
                    _light = new LightRepository(_context);
                return _light;
            }
        }

        private IVariableRepository? _variable = null;
        public IVariableRepository Variable
        {
            get
            {
                if (_variable is null)
                    _variable = new VariableRepository(_context);
                return _variable;
            }
        }

        private ISmokeRepository? _smoke = null;
        public ISmokeRepository Smoke
        {
            get
            {
                if (_smoke is null)
                    _smoke = new SmokeRepository(_context);
                return _smoke;
            }
        }

        private IRoomRepository? _room = null;
        public IRoomRepository Room
        {
            get
            {
                if (_room is null)
                    _room = new RoomRepository(_context);
                return _room;
            }
        }

        private IAgreementRepository? _agreement = null;
        public IAgreementRepository Agreement
        {
            get
            {
                if (_agreement is null)
                    _agreement = new AgreementRepository(_context);
                return _agreement;
            }
        }

        public AppRepositoryManager(AppDbContext context)
        {
            _context = context;
        }

    }
}
