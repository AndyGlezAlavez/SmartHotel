using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.gRPC.Mappers
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
                Unit = (LightUnit)light.Unit,
                //Room = light.Room.Map(),
            };
        }
        public static Domain.Entities.Light Map(this LightDTO lightDTO)
        {
            return new Domain.Entities.Light()
            {
                Id = new Guid(lightDTO.Id),
                Reference = lightDTO.Reference,
                Value = lightDTO.Value,
                Unit = (Domain.Types.LightUnit)lightDTO.Unit,
                //Room = lightDTO.Room.Map(),
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
