using SmartHotel.Domain.Entities;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.API.Mappers
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
                Room = (RoomDTO)Agreement.Room.Map(),
                StartDate = Agreement.Map().StartDate,
                FinalDate = Agreement.Map().FinalDate,
                Price = (Price)Agreement.Map().Price,
            };
        }
        public static SmartHotel.Domain.Entities.Agreement Map(this GrpcProtos.AgreementDTO AgreementDTO)
        {
            return new SmartHotel.Domain.Entities.Agreement()
            {
                Id = AgreementDTO.Map().Id,
                Clientemail = AgreementDTO.ClientEmail,
                ClientName = AgreementDTO.ClientName,
                RoomId = AgreementDTO.Map().RoomId,
                Room = AgreementDTO.Map().Room,
                StartDate = AgreementDTO.Map().StartDate,
                FinalDate = AgreementDTO.Map().FinalDate,
                Price = AgreementDTO.Map().Price,
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
