using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableRoomOfHotelsById;

public sealed record GetAvailableRoomOfHotelsByIdCommand(Guid Id) : IRequest<Result<string>>;

