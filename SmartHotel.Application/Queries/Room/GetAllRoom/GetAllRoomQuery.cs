using SmartHotel.Application.Common;

namespace SmartHotel.Application.Queries.Room.GetAllRoom
{
    public sealed record GetAllRoomQuery()
        : IQuery<IEnumerable<Domain.Entities.Room>>;
}

