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
    internal class AgreementEntityTypeConfiguration
    : EntityTypeConfigurationBase<Agreement>
    {
       public override void Configure(EntityTypeBuilder<Agreement> builder)
            {
                base.Configure(builder);
                builder.ToTable("Agreements");
                builder.OwnsOne(x => x.Price);
                
        }
        }
}