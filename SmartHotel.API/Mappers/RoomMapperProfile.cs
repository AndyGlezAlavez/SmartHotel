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
                LightId = Room.LightId.ToString(),
                Smoke = (SmokeDTO)Room.Smoke.Map(),
                SmokeId = Room.SmokeId.ToString(),
                Temperature = (TemperatureDTO)Room.Temperature.Map(),
                TemperatureId = Room.TemperatureId.ToString(),
                RoomType = (RoomType)Room.Map().RoomType,
                RentalPrice = (Price)Room.Map().RentalPrice,
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
