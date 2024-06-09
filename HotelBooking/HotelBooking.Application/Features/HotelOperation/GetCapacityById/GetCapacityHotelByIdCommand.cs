using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetCapacityById;

public sealed record GetCapacityHotelByIdCommand(
    Guid Id) : IRequest<Result<string>>;
