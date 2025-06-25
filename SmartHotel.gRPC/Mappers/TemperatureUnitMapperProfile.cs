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

namespace SmartHotel.gRPC.Mappers
{
    public static class TemperatureUnitMapperProfile
    {
        public static Domain.Types.TempUnit Map(this TempUnit tempUnit)
        {
            return new Domain.Types.TempUnit()
            { };
        }
    }
}