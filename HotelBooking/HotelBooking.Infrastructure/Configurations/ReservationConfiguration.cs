using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(p => p.Price)
            .HasColumnType("money");

        builder
            .HasOne(r => r.Hotel)
            .WithMany(h => h.Reservations!)
            .HasForeignKey(r => r.HotelId);

        builder.HasQueryFilter(x => !x.IsDeleted);


        //builder
        //    .HasOne(p => p.Room)
        //    .WithMany()
        //    .HasForeignKey(r => r.RoomId);



    }
}
