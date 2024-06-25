using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;

public class GetAvailableHotelsCommand : IRequest<Result<List<Hotel>>>
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public City City { get; set; } = default!;
}

