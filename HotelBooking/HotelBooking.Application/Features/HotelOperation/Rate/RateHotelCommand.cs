using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.Rate;

public sealed record RateHotelCommand(
    Guid ReservationId,
    int Rate
    ) : IRequest<Result<string>>;

