using MediatR;
using SmartHotel.GrpcProtos;

namespace SmartHotel.API.Mappers
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
                Light = (LightDTO)Room.Light.Map(),
                Smoke = (SmokeDTO)Room.Smoke.Map(),
                Temperature = (TemperatureDTO)Room.Temperature.Map(),
                RoomType = (RoomType)Room.Map().RoomType,
                RentalPrice = (Price)Room.Map().RentalPrice,
                Number = Room.Number,
                //Agreements = Room.Agreements,
            };
        }
        public static SmartHotel.Domain.Entities.Room Map(this GrpcProtos.RoomDTO Room)
        {
            return new SmartHotel.Domain.Entities.Room()
            {
                Id = Room.Map().Id,
                IsClimatizationOn = Room.IsClimatization,
                IsOcupated = Room.IsOcupated,
                IsIluminationOn = Room.IsIlumination,
                IsRentable = Room.IsRentable,
                Light = Room.Light.Map(),
                Smoke = Room.Smoke.Map(),
                Temperature = Room.Temperature.Map(),
                RoomType = Room.Map().RoomType,
                RentalPrice = Room.Map().RentalPrice,
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
