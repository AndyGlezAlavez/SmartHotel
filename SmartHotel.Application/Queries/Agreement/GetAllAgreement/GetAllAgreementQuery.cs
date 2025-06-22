using SmartHotel.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Agreement.GetAllAgreement
{
    public sealed record GetAllAgreementQuery : IQuery<IEnumerable<Domain.Entities.Agreement>>
    {
    }

}
