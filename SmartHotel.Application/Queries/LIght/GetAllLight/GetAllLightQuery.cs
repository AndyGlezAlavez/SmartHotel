using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.LIght.GetAllLight
{
    public sealed record GetAllLightQuery : IQuery<IEnumerable<Domain.Entities.Variable>>
    {
    }
}
