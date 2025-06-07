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
                //Light = (LightDTO)Room.Light,
                LightId = Room.LightId.ToString(),
                //Smoke = (SmokeDTO)Room.Smoke,
                SmokeId = Room.SmokeId.ToString(),
                //Temperature = (TemperatureDTO)Room.Temperature,
                TemperatureId = Room.TemperatureId.ToString(),
                //RoomType = (RoomType)Room.RoomType,
                //RentalPrice = (Price)Room.RentalPrice,
                Number = Room.Number,
                // = Room.Agreements,
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
