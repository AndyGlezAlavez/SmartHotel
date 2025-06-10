using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.AddAgreementToRoom
{
    public sealed record AddAgreementToRoomCommand(SmartHotel.Domain.Entities.Agreement Agreement)
    {
    }
}
