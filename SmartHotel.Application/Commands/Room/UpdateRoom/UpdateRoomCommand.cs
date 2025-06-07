using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Domain.Types;
using SmartHotel.Application.Common;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Commands.Room.UpdateRoom
{
    public sealed record UpdateRoomCommand(SmartHotel.Domain.Entities.Room Room) : ICommand
    {
    }
}