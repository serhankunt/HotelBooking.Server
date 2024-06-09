using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.ReservationOperation.Create;

public class CreateReservationCommand : IRequest<Result<string>>
{
    public string GuestFullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Guid HotelId { get; set; } = default!;
    public Guid RoomId { get; set; } = default!;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int AdultGuestCount { get; set; }
    public int ChildGuestCount { get; set; }
    public decimal? Price { get; set; }
}
