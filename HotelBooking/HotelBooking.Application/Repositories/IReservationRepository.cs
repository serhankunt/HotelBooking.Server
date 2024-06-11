
using GenericRepository;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Repositories;

public interface IReservationRepository : IRepository<Reservation>
{
    Task CreateAsync(Reservation reservation, CancellationToken cancellationToken);
    Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Reservation>> GetExpiredReservationsAsync(DateTime currentDate);
    Task UpdateAsync(Reservation reservation);

}
