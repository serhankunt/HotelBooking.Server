using HotelBooking.Application.Repositories;
using HotelBooking.Domain.DTOs;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;

public class GetAvailableHotelsCommandHandler(IHotelRepository hotelRepository) : IRequestHandler<GetAvailableHotelsCommand, Result<List<AvailableHotelDto>>>
{
    public async Task<Result<List<AvailableHotelDto>>> Handle(GetAvailableHotelsCommand request, CancellationToken cancellationToken)
    {
        var availableHotels = await hotelRepository.GetAvailableHotels(
           hotel => hotel.City == request.City &&
           hotel.Reservations.Where(y => request.CheckInDate < y.CheckOutDate).Any(y => request.CheckOutDate > y!.CheckInDate),
           request,
           cancellationToken
       );

        return Result<List<AvailableHotelDto>>.Succeed(availableHotels);

        //var availableHotels = await hotelRepository.GetAvailableHotels(
        //    hotel => hotel.City == request.City &&
        //    hotel.Reservations.Where(y => request.CheckInDate < y!.CheckOutDate)
        //    .Any(y => request.CheckOutDate > y!.CheckInDate),
        //    request,
        //    cancellationToken);

        //return Result<List<Hotel>>.Succeed(availableHotels);

    }
}

