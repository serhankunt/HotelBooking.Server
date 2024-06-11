using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.ReservationOperation.Delete;

public sealed record DeleteReservationCommand(
    Guid Id) : IRequest<Result<string>>;
