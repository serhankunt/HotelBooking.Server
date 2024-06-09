using HotelBooking.Application.Repositories;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableRoomOfHotelsById;

public class GetAvailableRoomOfHotelsByIdCommandHandler(IRoomRespository roomRespository) : IRequestHandler<GetAvailableRoomOfHotelsByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(GetAvailableRoomOfHotelsByIdCommand request, CancellationToken cancellationToken)
    {
        var count = await roomRespository.GetCapacityByIdAsync(request.Id, cancellationToken);

        return Result<string>.Succeed($"Otelin müsait oda sayýsý : {count}");
    }
}
