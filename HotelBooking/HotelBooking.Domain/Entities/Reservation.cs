using HotelBooking.Domain.Abstractions;

namespace HotelBooking.Domain.Entities;

public class Reservation : Entity
{
    public string GuestFullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Guid HotelId { get; set; } = default!;
    public Hotel Hotel { get; set; } = default!;
    public Guid RoomId { get; set; } = default!;
    //public Room Room { get; set; } = default!;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int AdultGuestCount { get; set; }
    public int ChildGuestCount { get; set; }
    public decimal Price { get; set; }
    public bool IsCompleted { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

}
