using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Light.UpdateLight
{
    public sealed record UpdateLightCommand(SmartHotel.Domain.Entities.Light Light) : ICommand
    {
    }
}
