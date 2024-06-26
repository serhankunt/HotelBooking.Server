using GenericRepository;
using HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;
using HotelBooking.Application.Features.HotelOperation.GetAvailableRoomOfHotelsById;
using HotelBooking.Domain.DTOs;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using System.Linq.Expressions;
using TS.Result;

namespace HotelBooking.Application.Repositories;

public interface IHotelRepository : IRepository<Hotel>
{
    Task CreateAsync(Hotel hotel);
    Task<List<Hotel>> GetAllHotel();
    Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Hotel?> GetHotelType(HotelType hotelType, CancellationToken cancellationToken);
    Task<List<AvailableHotelDto>> GetAvailableHotels(Expression<Func<Hotel, bool>> expression, GetAvailableHotelsCommand request, CancellationToken cancellationToken);
    Task<Result<string>> GetPercentageOfHotelIsFullAsync(GetAvailableRoomOfHotelsByIdCommand request, CancellationToken cancellationToken);
}
