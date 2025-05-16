using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    internal class Light : Variable
    {
        LightUnit unit { get; set; }
        public Light(Guid id, int number, LightUnit unit) : base(id, number)
        {
        }
    }
}
