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
    public static class RentalTypeMapperProfile
    {
        public static Domain.ValueObjects.RoomType Map(this GrpcProtos.RoomType roomType)
        {
            return new Domain.ValueObjects.RoomType()
            {
                Capacity = roomType.Map().Capacity,
                Category = roomType.Map().Category,
            };
        }
    }
}