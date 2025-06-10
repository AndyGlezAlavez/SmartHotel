using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.API.Mappers
{
    public static class LightMapperProfile
    {
        public static LightDTO Map(this Domain.Entities.Light light)
        {
            return new LightDTO()
            {
                Id = light.Id.ToString(),
                Reference = light.Reference,
                Value = light.Value,
                Unit = light.Map().Unit,
                Room = light.Room.Map(),
            };
        }
        public static Domain.Entities.Light Map(this GrpcProtos.LightDTO lightDTO)
        {
            return new Domain.Entities.Light()
            {
                Id = lightDTO.Map().Id,
                Reference = lightDTO.Reference,
                Value = lightDTO.Value,
                Unit = lightDTO.Map().Unit,
                Room = lightDTO.Room.Map(),
            };
        }
        public static Lights Map(this IEnumerable<Domain.Entities.Light> list)
        {
            var dto = new Lights();
            dto.Items.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}
