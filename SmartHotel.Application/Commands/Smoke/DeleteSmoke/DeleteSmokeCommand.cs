using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Domain.Types;
using SmartHotel.Application.Common;

namespace SmartHotel.Application.Commands.Smoke.DeleteSmoke
{
    public sealed record DeleteSmokeCommand(Guid ID) : ICommand
    {

    }
}
