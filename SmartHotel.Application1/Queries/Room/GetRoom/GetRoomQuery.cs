using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Room.GetRoom
{
    public sealed record GetRoomQuery(Guid Id)
        : IQuery<Domain.Entities.Room>;
}
