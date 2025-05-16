using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public class Light : Variable
    {
        LightUnit unit { get; set; } = 0;
        public Light(Guid id, int number, int reference, LightUnit unit) : base(id, number, reference)
        {
        }
    }
}
