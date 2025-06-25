using MediatR;
using SmartHotel.GrpcProtos;

namespace SmartHotel.gRPC.Mappers
{
    public static class RoomMapperProfile
    {
        public static RoomDTO Map(this Domain.Entities.Room Room)
        {
            return new RoomDTO()
            {
                Id = Room.Id.ToString(),
                IsClimatization = Room.IsClimatizationOn,
                IsOcupated = Room.IsOcupated,
                IsIlumination = Room.IsIluminationOn,
                IsRentable = Room.IsRentable,
                Light = Room.Light.Map(),
                Smoke = Room.Smoke.Map(),
                Temperature = Room.Temperature.Map(),
                RoomType = Room.RoomType.Map(),
                RentalPrice = Room.RentalPrice.Map(),
                Number = Room.Number,
                //Agreements = Room.Agreements,
            };
        }
        public static Domain.Entities.Room Map(this RoomDTO Room)
        {
            return new Domain.Entities.Room()
            {
                Id = new Guid (Room.Id),
                IsClimatizationOn = Room.IsClimatization,
                IsOcupated = Room.IsOcupated,
                IsIluminationOn = Room.IsIlumination,
                IsRentable = Room.IsRentable,
                Light = Room.Light.Map(),
                Smoke = Room.Smoke.Map(),
                Temperature = Room.Temperature.Map(),
                RoomType = Room.RoomType.Map(),
                RentalPrice = Room.RentalPrice.Map(),
                Number = Room.Number,
                //Agreements = Room.Agreements,
            };
        }

        public static Rooms Map(this IEnumerable<Domain.Entities.Room> list)
        {
            var dto = new Rooms();
            dto.Item.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}
