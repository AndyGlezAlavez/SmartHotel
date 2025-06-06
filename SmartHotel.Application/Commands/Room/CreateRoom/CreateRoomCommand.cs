using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Application.Common;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using SmartHotel.Domain.ValueObjects;
namespace SmartHotel.Application.Commands.Room.CreateRoom
{
    public sealed record CreateRoomCommand(Guid Id, int Number, Price RentalPrice, RoomType RoomType, SmartHotel.Domain.Entities.Temperature Temperature, SmartHotel.Domain.Entities.Smoke Smoke, SmartHotel.Domain.Entities.Light Light) : ICommand
    {

    }
}
