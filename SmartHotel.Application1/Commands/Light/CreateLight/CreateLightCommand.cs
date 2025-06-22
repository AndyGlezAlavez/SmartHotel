using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Application.Common;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;

namespace SmartHotel.Application.Commands.Light.CreateLight
{
    public sealed record CreateLightCommand(LightUnit LightUnit, double Value, double Reference, SmartHotel.Domain.Entities.Room Room) : ICommand
    {

    }
}
