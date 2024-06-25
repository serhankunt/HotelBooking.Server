using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.DTOs;

public class AvailableHotelDto
{
    public string Name { get; set; } = default!;
    public City City { get; set; } = default!;
    public string Town { get; set; } = default!;
    public decimal Rating { get; set; }
    public int TotalReview { get; set; }
    public HotelType HotelType { get; set; } = default!;
    public List<RoomDto> Rooms { get; set; } = default!;
}
public class RoomDto
{
    public RoomType RoomType { get; set; } = default!;
    public int TotalRoomCount { get; set; }
    public int AvailableRoomCount { get; set; }
    public decimal Price { get; set; }
}