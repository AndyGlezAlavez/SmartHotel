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
    public static class SmokeUnitMapperProfile
    {
        public static Domain.Types.SmokeUnit Map(this GrpcProtos.SmokeUnit smokeUnit)
        {
            return new Domain.Types.SmokeUnit()
            { };
        }
    }
}