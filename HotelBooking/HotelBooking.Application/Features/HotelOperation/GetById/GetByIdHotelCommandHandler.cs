using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetById;

public class GetByIdHotelCommandHandler(
    IHotelRepository hotelRepository) : IRequestHandler<GetByIdHotelCommand, Result<Hotel>>
{
    public async Task<Result<Hotel>> Handle(GetByIdHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id, cancellationToken);

        if (hotel == null)
        {
            throw new ArgumentException();
        }

        Result<Hotel> result = hotel;

        return result;
    }
}
