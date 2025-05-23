using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Persistence.FluentConfigurations.Common;
using SmartHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHotel.Persistence.FluentConfigurations
{
    internal class VariableEntityTypeConfiguration : EntityTypeConfigurationBase<Variable>
    {
        public override void Configure(EntityTypeBuilder<Variable> builder)
        {
            base.Configure(builder);
            builder.ToTable("Variables");
        }
    }
}
