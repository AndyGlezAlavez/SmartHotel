using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.API.Mappers
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
                //Unit = temperature.Unit,
                //Room = temperature.Room,
                };
        }

        public static Temperatures Map(this IEnumerable<Domain.Entities.Temperature> list)
        {
            var dto = new Temperatures();
            dto.Items.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}
