using HotelBooking.Domain.Abstractions;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.Entities;

public sealed class Room : Entity
{
    public RoomType RoomType { get; set; } = default!;
    public int Quantity { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = default!;
}
