using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Application.Common;

namespace SmartHotel.Application.Queries.Smoke.GetAllsSmoke
{
    
        public sealed record GetAllsSmokesQuery()
            : IQuery<IEnumerable<Domain.Entities.Smoke>>;
    }
