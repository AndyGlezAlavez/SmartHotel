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
            builder.OwnsOne(room => room.RoomType);
            builder.OwnsOne(room => room.RentalPrice);
            builder.HasMany(r => r.Agreements).WithOne().HasForeignKey(x => x.RoomId);
            builder.HasOne(r => r.Smoke).WithOne(s => s.Room).HasForeignKey<Room>(r => r.SmokeId);
            builder.HasOne(r => r.Light).WithOne(s => s.Room).HasForeignKey<Room>(r => r.LightId);
        }
    }
}