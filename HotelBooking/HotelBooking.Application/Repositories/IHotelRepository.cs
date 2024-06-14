using GenericRepository;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using System.Linq.Expressions;

namespace HotelBooking.Application.Repositories;

public interface IHotelRepository : IRepository<Hotel>
{
    Task CreateAsync(Hotel hotel);
    Task<List<Hotel>> GetAllHotel();
    Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Hotel?> GetHotelType(HotelType hotelType, CancellationToken cancellationToken);
    Task<List<Hotel>> GetAvailableHotels(Expression<Func<Hotel, bool>> expression, CancellationToken cancellationToken);
}
