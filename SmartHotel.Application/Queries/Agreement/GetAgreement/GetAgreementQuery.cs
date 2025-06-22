using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Agreement.GetAgreement
{
    public sealed record GetAgreementQuery(Guid Id)
        : IQuery<Domain.Entities.Agreement>;
}
