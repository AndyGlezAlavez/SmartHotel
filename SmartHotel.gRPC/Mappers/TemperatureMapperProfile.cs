using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.gRPC.Mappers
{
    public static class TemperatureMapperProfile
    {
        public static TemperatureDTO Map(this Domain.Entities.Temperature temperature)
        {
            return new TemperatureDTO()
            {
                Id = temperature.Id.ToString(),
                Reference = temperature.Reference,
                Value = temperature.Value,
                Unit = (TempUnit)temperature.Unit,
                //Room = temperature.Room.Map(),
                };
        }
        public static Domain.Entities.Temperature Map(this TemperatureDTO temperatureDTO)
        {
            try
            {
                return new Domain.Entities.Temperature()
                {
                    Id = new Guid(temperatureDTO.Id),
                    Reference = temperatureDTO.Reference,
                    Value = temperatureDTO.Value,
                    Unit = (Domain.Types.TempUnit)temperatureDTO.Unit,
                    //Room = temperatureDTO.Room.Map(),
                };
            }catch(Exception e)
            {
                throw e;
            }
        }
        public static Temperatures Map(this IEnumerable<Domain.Entities.Temperature> list)
        {
            var dto = new Temperatures();
            dto.Items.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}
