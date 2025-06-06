using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories.Managers
{
    public interface IAppRepositoryManager
    {
        IRoomRepsoitory Room { get; }
        IVariableRepository Variable { get; }
        IAgreementRepository Agreement { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
