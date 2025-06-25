using Google.Protobuf.WellKnownTypes;
using MediatR;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.ValueObjects;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.gRPC.Mappers
{
    public static class PriceMapperProfile
    {
        public static Domain.ValueObjects.Price Map(this GrpcProtos.Price price)
        {
            return new Domain.ValueObjects.Price()
            {
                Value = price.Value,
                MoneyType = (Domain.Types.MoneyType)price.MoneyType,
            };
        }
        public static GrpcProtos.Price Map(this Domain.ValueObjects.Price price)
        {
            return new GrpcProtos.Price()
            {
                Value = price.Value,
                MoneyType = (GrpcProtos.MoneyTipe)price.MoneyType,
            };
        }
    }
}
