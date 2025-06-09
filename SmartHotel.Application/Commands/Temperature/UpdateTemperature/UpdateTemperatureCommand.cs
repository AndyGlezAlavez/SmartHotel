using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Domain.Types;
using SmartHotel.Application.Common;

namespace SmartHotel.Application.Commands.Temperature.UpdateTemperature
{
    public sealed record UpdateTemperatureCommand(SmartHotel.Domain.Entities.Temperature Temperature) : ICommand
    {
    }
}
