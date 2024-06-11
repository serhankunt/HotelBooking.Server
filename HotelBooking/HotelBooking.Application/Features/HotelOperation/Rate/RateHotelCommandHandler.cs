using HotelBooking.Application.Repositories;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.Rate;

public class RateHotelCommandHandler(
    IReservationRepository reservationRepository,
    IHotelRepository hotelRepository) : IRequestHandler<RateHotelCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RateHotelCommand request, CancellationToken cancellationToken)
    {
        var isReservationExist = await reservationRepository.AnyAsync(p => p.Id == request.ReservationId);
        if (isReservationExist)
        {
            return Result<string>.Failure("Rezervasyon bilgisine ulaþýlamadý");
        }

        var reservation = await reservationRepository.FirstOrDefaultAsync(p => p.Id == request.ReservationId);

        var hotel = await hotelRepository.FirstOrDefaultAsync(p => p.Id == reservation.HotelId);
        if (hotel is null)
        {
            return Result<string>.Failure("Otel bulunamadý");
        }

        hotel.Rating = request.Rate;

        hotelRepository.Update(hotel);

        return Result<string>.Succeed("Deðerlendirmeniz baþarýyla ulaþtý.");

    }
}
