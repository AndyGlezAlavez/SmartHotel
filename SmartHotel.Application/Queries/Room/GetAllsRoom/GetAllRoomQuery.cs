using SmartHotel.Application.Common;

namespace SmartHotel.Application.Queries.Room.GetAllsRoom
{
    public sealed record GetAllRoomQuery()
        : IQuery<IEnumerable<Domain.Entities.Room>>;
}

