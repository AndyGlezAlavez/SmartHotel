using Google.Protobuf.WellKnownTypes;
using MediatR;
using SmartHotel.Domain.Entities;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
                Unit = smoke.Map().Unit,
                Room = smoke.Room.Map(),
            };
        }
        public static Domain.Entities.Smoke Map(this GrpcProtos.SmokeDTO smokeDTO)
        {
            return new Domain.Entities.Smoke() 
            {
                Id = smokeDTO.Map().Id,
                Reference = smokeDTO.Reference,
                Value = smokeDTO.Value,
                Unit = smokeDTO.Map().Unit,
                Room = smokeDTO.Room.Map(),
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
