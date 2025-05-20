using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHotel.Domain.ValueObjects;

namespace SmartHotel.Persistence.FluentConfigurations
{
    internal class RoomEntityTypeConfiguration
        : EntityTypeConfigurationBase<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);
            builder.ToTable("Rooms");
            builder.OwnsOne(x => x.RoomType);
            builder.HasMany(x => x.Agreements).WithOne().HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.Smoke);
            builder.HasOne(x => x.Light);
            builder.HasOne(x => x.Temperature);
        }
    }
}