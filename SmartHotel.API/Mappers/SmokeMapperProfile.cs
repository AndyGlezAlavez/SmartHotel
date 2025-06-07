using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.API.Mappers
{
    public static class SmokeMapperProfile
    {
        public static SmokeDTO Map(this Domain.Entities.Smoke smoke)
        {
            return new SmokeDTO()
            {
                Id = smoke.Id.ToString(),
                Reference = smoke.Reference,
                Value = smoke.Value,
                //Unit = smoke.Unit,
                //Room = smoke.Room,
            };
        }

        public static Smokes Map(this IEnumerable<Domain.Entities.Smoke> list)
        {
            var dto = new Smokes();
            dto.Items.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}
