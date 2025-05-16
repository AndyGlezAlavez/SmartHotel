using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public class Smoke : Variable
    {
        SmokeUnit unit { get; set; } = 0;
        public Smoke(Guid id, int number, int reference, SmokeUnit unit= 0) : base(id, number, reference)
        {
        }
    }
}
