using HotelBooking.Application.Repositories;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetCapacityById;

public class GetCapacityHotelByIdCommandHandler(
    IRoomRespository roomRespository) : IRequestHandler<GetCapacityHotelByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(GetCapacityHotelByIdCommand request, CancellationToken cancellationToken)
    {
        var count = await roomRespository.GetCapacityByIdAsync(request.Id, cancellationToken);

        return Result<string>.Succeed($"Otelin kapasitesi : {count}");
    }
}
