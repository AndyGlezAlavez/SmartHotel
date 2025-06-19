using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories.Managers
{
    public interface IAppRepositoryManager
    {
        IRoomRepository Room { get; }
        //IVariableRepository Variable { get; }
        IAgreementRepository Agreement { get; }

        ISmokeRepository Smoke { get; }
        ITemperatureRepository Temperature { get; }

        ILightRepository Light { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
