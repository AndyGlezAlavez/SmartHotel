using SmartHotel.Contracts.Repositories;
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
                if (_variable is null)
                    _variable = new VariableRepository(_context);
                return _variable;
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
