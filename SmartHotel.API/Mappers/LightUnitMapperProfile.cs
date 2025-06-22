using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.API.Mappers
{
    public static class LightUnitMapperProfile
    {
        public static Domain.Types.LightUnit Map(this GrpcProtos.LightUnit lightUnit)
        {
            return new Domain.Types.LightUnit()
            { };
        }
}
}
