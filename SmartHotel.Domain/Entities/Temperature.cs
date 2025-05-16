using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public class Temperature : Variable
    {
        TempUnit unit { get; set; } = 0;
        public Temperature(Guid id, int number, int reference, TempUnit unit) : base(id, number, reference)
        {
        }
    }
}
