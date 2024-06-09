using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetById;

public sealed record GetByIdHotelCommand(
    Guid Id) : IRequest<Result<Hotel>>;
