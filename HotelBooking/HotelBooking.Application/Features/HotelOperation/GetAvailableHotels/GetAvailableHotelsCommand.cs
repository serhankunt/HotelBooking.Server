using HotelBooking.Domain.DTOs;
using HotelBooking.Domain.Enums;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;

public class GetAvailableHotelsCommand : IRequest<Result<List<AvailableHotelDto>>>
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public City City { get; set; } = default!;
}

