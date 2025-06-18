using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Agreement.DeleteAgreement
{
    public sealed record  DeleteAgreementCommand (Guid ID) : ICommand
    {
    }
}
