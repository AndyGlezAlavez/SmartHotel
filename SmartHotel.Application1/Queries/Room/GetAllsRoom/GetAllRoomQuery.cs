using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Room.GetAllsRoom
{
    public sealed record GetAllRoomQuery()
        : IQuery<IEnumerable<Domain.Entities.Room>>;
}

