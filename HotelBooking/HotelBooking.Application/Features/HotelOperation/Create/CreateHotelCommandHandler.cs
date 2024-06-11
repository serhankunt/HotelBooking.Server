using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.Create;

public class CreateHotelCommandHandler(IHotelRepository hotelRepository) : IRequestHandler<CreateHotelCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var isHotelNameExist = await hotelRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isHotelNameExist)
        {
            return Result<string>.Failure("Otel adý daha önce kullanýlmýþ");
        }

        var hotel = new Hotel
        {
            Name = request.Name,
            City = request.City,
            Town = request.Town,
            HotelType = request.HotelType,
            Rooms = new List<Room>()
        };

        if (request.Rooms is not null)
        {
            foreach (var roomCommand in request.Rooms)
            {
                var room = new Room
                {
                    RoomType = roomCommand.RoomType,
                    TotalRoomCount = roomCommand.Quantity,
                    AvailableRoomCount = roomCommand.Quantity,
                    Hotel = hotel
                };

                hotel.Rooms.Add(room);
            }
        }

        await hotelRepository.AddAsync(hotel, cancellationToken);
        return Result<string>.Succeed("Otel baþarýyla oluþturuldu");

    }
}
