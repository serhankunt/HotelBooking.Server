using GenericRepository;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Repositories;

public interface IRoomRespository : IRepository<Room>
{
    Task CreateAsync(Room room);
    Task<int> GetCapacityByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Room?> GetHotelType(RoomType roomType, CancellationToken cancellationToken);
}