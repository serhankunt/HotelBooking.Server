using HotelBooking.Domain.Abstractions;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.Entities;

public sealed class Hotel : Entity
{
    public string Name { get; set; } = default!;
    public City City { get; set; } = default!;
    public string Town { get; set; } = default!;
    public decimal? Rating { get; set; }
    public HotelType HotelType { get; set; } = default!;
    public ICollection<Room> Rooms { get; set; } = default!;


}
