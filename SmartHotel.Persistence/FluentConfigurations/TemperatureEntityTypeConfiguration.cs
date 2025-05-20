using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.FluentConfigurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Persistence.FluentConfigurations
{
    internal class TemperatureEntityTypeConfiguration : EntityTypeConfigurationBase<Temperature>
    {
        public override void Configure(EntityTypeBuilder<Temperature> builder)
        {
            builder.HasBaseType<Variable>();
            builder.ToTable("Temperatures");
            //  builder.OwnsOne(x => x.Unit);  Duda
        }
    }
}
