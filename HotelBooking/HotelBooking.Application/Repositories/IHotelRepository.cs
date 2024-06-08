using GenericRepository;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Repositories;

public interface IHotelRepository : IRepository<Hotel>
{
    Task CreateAsync(Hotel hotel);
    Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Hotel?> GetHotelType(HotelType hotelType, CancellationToken cancellationToken);
}
