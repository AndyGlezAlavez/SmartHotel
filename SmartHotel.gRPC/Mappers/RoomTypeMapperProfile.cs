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
    public static class RentalTypeMapperProfile
    {
        public static Domain.ValueObjects.RoomType Map(this RoomType roomType)
        {
            return new Domain.ValueObjects.RoomType()
            {
                Capacity = (Domain.Types.Capacity)roomType.Capacity,
                Category = (Domain.Types.Category)roomType.Category,
            };
        }
        public static GrpcProtos.RoomType Map(this Domain.ValueObjects.RoomType roomType)
        {
            return new GrpcProtos.RoomType()
            {
                Capacity = (GrpcProtos.Capacity)roomType.Capacity,
                Category = (GrpcProtos.Category)roomType.Category,
            };
        }
    }
}