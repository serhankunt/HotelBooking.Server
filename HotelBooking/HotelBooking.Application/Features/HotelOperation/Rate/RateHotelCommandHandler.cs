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
        try
        {
            var isReservationExist = await reservationRepository.AnyAsync(p => p.Id == request.ReservationId);
            if (!isReservationExist)
            {
                return Result<string>.Failure("Rezervasyon bilgisine ulaþýlamadý");
            }

            var reservation = await reservationRepository.FirstOrDefaultAsync(p => p.Id == request.ReservationId);

            var hotel = await hotelRepository.FirstOrDefaultAsync(p => p.Id == reservation.HotelId);
            if (hotel is null)
            {
                return Result<string>.Failure("Otel bulunamadý");
            }
            if (!reservation.IsCompleted)
            {
                return Result<string>.Failure("Tatil tamamlanmadan puan verilemez");
            }

            var totalRating = hotel.TotalReview * hotel.Rating;
            totalRating += request.Rate;
            hotel.TotalReview += 1;

            hotel.Rating = totalRating / hotel.TotalReview;

            hotelRepository.Update(hotel);

            return Result<string>.Succeed("Deðerlendirmeniz baþarýyla ulaþtý.");
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Result<string>.Failure("Bir hatayla karþýlaþýldý");
        }


    }
}
