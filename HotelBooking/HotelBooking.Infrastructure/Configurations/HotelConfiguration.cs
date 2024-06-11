using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Configurations;

public sealed class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder
            .Property(p => p.Name)
            .HasColumnType("varchar(75)");

        builder.Property(p => p.Rating)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.City)
            .HasConversion(v => v.Value, v => City.FromValue(v));

        builder.Property(p => p.HotelType)
            .HasConversion(v => v.Value, v => HotelType.FromValue(v));

        //builder.Property(p => p.HotelType.Value)
        //    .HasConversion<int>();

        builder.Property(p => p.Rating)
            .HasDefaultValue(0)
            .HasColumnType("decimal(2,2)");

        builder.Property(p => p.TotalReview)
            .HasDefaultValue(0);

        builder
            .HasMany(p => p.Rooms)
            .WithOne(p => p.Hotel)
            .HasForeignKey(p => p.HotelId);
    }
}
