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
                return Result<string>.Failure("Rezervasyon bilgisine ula��lamad�");
            }

            var reservation = await reservationRepository.FirstOrDefaultAsync(p => p.Id == request.ReservationId);

            var hotel = await hotelRepository.FirstOrDefaultAsync(p => p.Id == reservation.HotelId);
            if (hotel is null)
            {
                return Result<string>.Failure("Otel bulunamad�");
            }
            if (!reservation.IsCompleted)
            {
                return Result<string>.Failure("Tatil tamamlanmadan puan verilemez");
            }
            if (reservation.IsDeleted)
            {
                return Result<string>.Failure("Bu rezervasyon iptal edildi�i i�in puanlama yap�lamaz");
            }
            if (reservation.IsRated)
            {
                return Result<string>.Failure("Otel daha �nce puanland�");
            }


            var totalRating = hotel.TotalReview * hotel.Rating;
            totalRating += request.Rate;
            hotel.TotalReview += 1;

            hotel.Rating = totalRating / hotel.TotalReview;
            reservation.IsRated = true;

            reservationRepository.Update(reservation);
            hotelRepository.Update(hotel);

            return Result<string>.Succeed("De�erlendirmeniz ba�ar�yla ula�t�.");
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Result<string>.Failure($"Bir hatayla kar��la��ld�:{ex}");
        }


    }
}
