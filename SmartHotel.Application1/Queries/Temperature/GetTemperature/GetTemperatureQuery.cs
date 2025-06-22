using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Temperature.GetTemperature
{
    public sealed record GetTemperatureQuery(Guid Id)
        : IQuery<Domain.Entities.Temperature>;
}
