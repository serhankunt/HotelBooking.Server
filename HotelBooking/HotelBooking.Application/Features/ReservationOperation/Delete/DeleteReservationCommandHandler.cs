using HotelBooking.Application.Repositories;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.ReservationOperation.Delete;

public class DeleteReservationCommandHandler(
    IReservationRepository reservationRepository) : IRequestHandler<DeleteReservationCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await reservationRepository.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (reservation is null)
        {
            return Result<string>.Failure("Rezervasyon bulunamadý");
        }

        if ((reservation.CheckInDate - DateTime.UtcNow).TotalDays < 1)
        {
            return Result<string>.Failure("Rezervasyon iptal edilemez");
        }

        if (reservation.IsCompleted == true)
        {
            return Result<string>.Failure("Rezervasyon tarihi geçmiþ");
        }


        reservation.IsDeleted = true;

        await reservationRepository.UpdateAsync(reservation);

        return Result<string>.Succeed("Rezervasyon baþarýyla iptal edildi");

    }
}
