using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableRoomOfHotelsById;

public sealed class GetAvailableRoomOfHotelsByIdCommand : IRequest<Result<string>>
{
    public Guid Id { get; set; } = default!;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

}


