using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHotel.Persistence.FluentConfigurations
{
    internal class RoomEntityTypeConfiguration
        : EntityTypeConfigurationBase<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);
            builder.ToTable("Rooms");
            builder.OwnsOne(x => x.Agreements);
            builder.OwnsOne(x => x.Light);
            builder.OwnsOne(x => x.Smoke);
            builder.OwnsOne(x => x.Temperature);
        }
    }
}