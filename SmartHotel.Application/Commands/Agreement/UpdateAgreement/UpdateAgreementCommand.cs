using SmartHotel.Application.Common;
using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Agreement.UpdateAgreement
{
    public sealed record  UpdateAgreementCommand(SmartHotel.Domain.Entities.Agreement Agreement) : ICommand
    {
    }
}
