using HotelBooking.Application.Repositories;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableRoomOfHotelsById;

public class GetAvailableRoomOfHotelsByIdCommandHandler(IHotelRepository hotelRepository) : IRequestHandler<GetAvailableRoomOfHotelsByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(GetAvailableRoomOfHotelsByIdCommand request, CancellationToken cancellationToken)
    {

        var hotelOccupancyRate = await hotelRepository.GetPercentageOfHotelIsFullAsync(request, cancellationToken);

        return hotelOccupancyRate;
    }
}
