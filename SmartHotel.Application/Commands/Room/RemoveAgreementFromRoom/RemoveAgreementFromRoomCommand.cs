using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.RemoveAgreementFromRoom
{
    public sealed record RemoveAgreementFromRoomCommand (Guid Id)
    {
    }
}
