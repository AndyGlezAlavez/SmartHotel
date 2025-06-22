using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Light.GetLight
{
    public sealed record GetLightQuery(Guid Id)
        : IQuery<Domain.Entities.Light>;
}
