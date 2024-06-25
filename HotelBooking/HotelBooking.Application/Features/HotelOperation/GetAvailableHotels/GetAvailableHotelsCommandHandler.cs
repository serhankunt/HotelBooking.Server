using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;

public class GetAvailableHotelsCommandHandler(IHotelRepository hotelRepository) : IRequestHandler<GetAvailableHotelsCommand, Result<List<Hotel>>>
{
    public async Task<Result<List<Hotel>>> Handle(GetAvailableHotelsCommand request, CancellationToken cancellationToken)
    {

        var availableHotels = await hotelRepository.GetAvailableHotels(
            hotel => hotel.City == request.City &&
            hotel.Reservations.Where(y => request.CheckInDate < y!.CheckOutDate)
            .Any(y => request.CheckOutDate > y!.CheckInDate),
            request,
            cancellationToken);



        return Result<List<Hotel>>.Succeed(availableHotels);

    }
}

