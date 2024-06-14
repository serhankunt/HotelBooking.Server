using HotelBooking.Domain.Abstractions;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.Entities;

public sealed class Room : Entity
{
    public RoomType RoomType { get; set; } = default!;
    public int TotalRoomCount { get; set; }
    public int AvailableRoomCount { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = default!;
    public decimal Price { get; set; } = default!;
}
