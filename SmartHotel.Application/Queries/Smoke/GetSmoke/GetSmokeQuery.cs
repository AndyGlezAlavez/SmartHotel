using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Application.Common;

namespace SmartHotel.Application.Queries.Smoke.GetSmoke
{

    public sealed record GetSmokeQuery(Guid Id)
        : IQuery<Domain.Entities.Smoke>;
}
