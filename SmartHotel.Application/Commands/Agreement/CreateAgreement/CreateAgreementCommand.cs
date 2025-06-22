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
namespace SmartHotel.Application.Commands.Agreement.CreateAgreement
{
    public sealed record CreateAgreementCommand(string Clientname,
                                                string Clientemail,
                                                DateTime StartDate,
                                                DateTime FinalDate,
                                                SmartHotel.Domain.Entities.Room Room,
                                                String Id,
                                                Price Price) : ICommand

    {

    }
}
