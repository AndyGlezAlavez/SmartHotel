using Google.Protobuf.WellKnownTypes;
using SmartHotel.Domain.Entities;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.gRPC.Mappers
{
    public static class AgreementMapperProfile
    {
        public static AgreementDTO Map(this Domain.Entities.Agreement Agreement)
        {
            return new AgreementDTO()
            {
                Id = Agreement.Id.ToString(),
                ClientEmail= Agreement.Clientemail,
                ClientName = Agreement.ClientName,
                RoomId = Agreement.RoomId.ToString(),
                Room = Agreement.Room.Map(),
                StartDate = Agreement.StartDate.ToTimestamp(),
                FinalDate = Agreement.FinalDate.ToTimestamp(),
                Price = Agreement.Price.Map(),
            };
        }
        public static Domain.Entities.Agreement Map(this AgreementDTO AgreementDTO)
        {
            return new Domain.Entities.Agreement()
            {
                Id = new Guid(AgreementDTO.Id),
                Clientemail = AgreementDTO.ClientEmail,
                ClientName = AgreementDTO.ClientName,
                RoomId = new Guid(AgreementDTO.RoomId),
                Room = AgreementDTO.Room.Map(),
                StartDate = AgreementDTO.StartDate.ToDateTime(),
                FinalDate = AgreementDTO.FinalDate.ToDateTime(),
                Price = AgreementDTO.Price.Map(),
            };
        }

        public static Agreements Map(this IEnumerable<Domain.Entities.Agreement> list)
        {
            var dto = new Agreements();
            dto.Item.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}
