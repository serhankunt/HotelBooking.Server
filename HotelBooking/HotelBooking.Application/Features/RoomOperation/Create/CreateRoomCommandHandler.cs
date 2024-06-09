using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.RoomOperation.Create;

public class CreateRoomCommandHandler(
    IHotelRepository hotelRepository,
    IRoomRespository roomRespository) : IRequestHandler<CreateRoomCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.HotelId, cancellationToken = default);
        if (hotel is null)
        {
            return Result<string>.Failure("Oda i�in ge�erli bir otel giriniz.");
        }

        if (request.Quantity < 1)
        {
            return Result<string>.Failure("L�tfen oda say�s� belirtiniz");
        }

        var room = new Room
        {
            RoomType = request.RoomType,
            Quantity = request.Quantity,
            HotelId = request.HotelId
        };

        await roomRespository.AddAsync(room);
        return Result<string>.Succeed("Oda ba�ar�l� bir �ekilde olu�turuldu");

    }
}
