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
    internal class SmokeEntityTypeConfiguration : EntityTypeConfigurationBase<Smoke>
    {
        public override void Configure(EntityTypeBuilder<Smoke> builder)
        {
            builder.HasBaseType<Variable>();
            builder.ToTable("Smokes");
            //builder.OwnsOne(x => x.Unit); Fix this     
        }
    }
}
