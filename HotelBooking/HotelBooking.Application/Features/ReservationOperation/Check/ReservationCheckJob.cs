using HotelBooking.Application.Repositories;

namespace HotelBooking.Application.Features.ReservationOperation.Check;

public class ReservationCheckJob(IReservationRepository reservationRepository,
    IRoomRespository roomRepository)
{
    public async Task CheckExpiredReservations()
    {
        var expiredReservations = await reservationRepository.GetExpiredReservationsAsync(DateTime.Now);

        foreach (var reservation in expiredReservations)
        {
            var room = await roomRepository.GetByIdAsync(reservation.RoomId);
            if (room is not null)
            {
                room.AvailableRoomCount += 1;
                reservation.IsCompleted = true;
                roomRepository.UpdateAsync(room);

            }

            await reservationRepository.UpdateAsync(reservation);
        }
    }
}
