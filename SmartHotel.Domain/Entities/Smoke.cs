using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    internal class Smoke : Variable
    {
        SmokeUnit unit { get; set; }
        public Smoke(Guid id, int number, SmokeUnit unit) : base(id, number)
        {
        }
    }
}
