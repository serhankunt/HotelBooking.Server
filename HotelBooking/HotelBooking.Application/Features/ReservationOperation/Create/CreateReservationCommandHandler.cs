using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.ReservationOperation.Create;

public class CreateReservationCommandHandler(
    IHotelRepository hotelRepository,
    IRoomRespository roomRespository,
    IReservationRepository reservationRepository) : IRequestHandler<CreateReservationCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var isHotelExist = await hotelRepository.AnyAsync(p => p.Id == request.HotelId);
        if (!isHotelExist)
        {
            return Result<string>.Failure("Otel bulunamadý");
        }

        var isRoomExist = await roomRespository.AnyAsync(p => p.Id == request.RoomId);
        if (!isRoomExist)
        {
            return Result<string>.Failure("Oda bulunamadý");
        }

        if (request.CheckOutDate.Date < request.CheckInDate.Date)
        {
            return Result<string>.Failure("Çýkýþ tarihi giriþ tarihinden önce olamaz");
        }

        decimal Price = (decimal)((request.CheckOutDate.Date - request.CheckInDate.Date).Days) * request.AdultGuestCount * 1000;

        var reservation = new Reservation
        {
            GuestFullName = request.GuestFullName,
            Email = request.Email,
            HotelId = request.HotelId,
            RoomId = request.RoomId,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            AdultGuestCount = request.AdultGuestCount,
            ChildGuestCount = request.ChildGuestCount,
            Price = Price,
        };

        await reservationRepository.AddAsync(reservation);
        return Result<string>.Succeed("Rezervasyon kaydýnýz baþarýlý bir þekilde oluþturuldu.");
    }
}
