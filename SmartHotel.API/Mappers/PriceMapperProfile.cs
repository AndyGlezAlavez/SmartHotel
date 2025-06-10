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

namespace SmartHotel.API.Mappers
{
    public static class PriceMapperProfile
    {
        public static Domain.ValueObjects.Price Map(this GrpcProtos.Price price)
        {
            return new Domain.ValueObjects.Price()
            {
                Value = price.Value,
                MoneyType = price.Map().MoneyType,
            };
        }
    }
}
