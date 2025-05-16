using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    internal class Temperature : Variable
    {
        TempUnit unit { get; set; }
        public Temperature(Guid id, int number, TempUnit unit) : base(id, number)
        {
        }
    }
}
