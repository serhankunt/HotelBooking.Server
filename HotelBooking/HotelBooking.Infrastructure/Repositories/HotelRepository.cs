using HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;
using HotelBooking.Application.Repositories;
using HotelBooking.Domain.DTOs;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBooking.Infrastructure.Repositories;

public class HotelRepository(ApplicationDbContext context) : IHotelRepository
{

    public async Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Hotel>().FindAsync(new object[] { id }, cancellationToken);
    }
    public async Task CreateAsync(Hotel hotel)
    {
        await context.Set<Hotel>().AddAsync(hotel);
        await context.SaveChangesAsync();
    }
    public async Task<Hotel?> GetHotelTypeAsync(HotelType hotelType, CancellationToken cancellationToken)
    {
        return await context.Set<Hotel>().FirstOrDefaultAsync(h => h.HotelType == hotelType, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<Hotel, bool>> expression, CancellationToken cancellationToken)
    {
        return await context.Set<Hotel>().AnyAsync(expression, cancellationToken);
    }

    public async Task AddAsync(Hotel entity, CancellationToken cancellationToken = default)
    {
        await context.Set<Hotel>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task<Hotel?> FirstOrDefaultAsync(Expression<Func<Hotel, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
    {
        return await context.Set<Hotel>().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<List<AvailableHotelDto>> GetAvailableHotels(Expression<Func<Hotel, bool>> expression, GetAvailableHotelsCommand request, CancellationToken cancellationToken)
    {
        var hotels = await context.Hotels
           .Where(p => p.City == request.City)
           .Include(h => h.Rooms)
           .Include(h => h.Reservations)
           .ToListAsync(cancellationToken);

        var availableHotels = new List<Hotel>();

        foreach (var hotel in hotels)
        {
            bool isAvailable = true;

            for (DateTime date = request.CheckInDate; date < request.CheckOutDate; date = date.AddDays(1))
            {
                int availableRooms = hotel.Rooms.Sum(room => room.TotalRoomCount);

                foreach (var reservation in hotel.Reservations)
                {
                    if (reservation is null)
                    {
                        break;
                    }
                    if (reservation.CheckInDate <= date && reservation.CheckOutDate > date)
                    {
                        availableRooms--;
                    }
                }

                if (availableRooms <= 0)
                {
                    isAvailable = false;
                    break;
                }
            }

            if (isAvailable)
            {
                availableHotels.Add(hotel);
            }
        }

        #region Deneme1
        //foreach (var hotel in hotels)
        //{
        //    bool isAvailable = true;

        //    // Check availability for each room type
        //    foreach (var room in hotel.Rooms)
        //    {
        //        int initialAvailableRoomCount = room.AvailableRoomCount;

        //        // Calculate available rooms for each day in the range
        //        for (DateTime date = request.CheckInDate; date < request.CheckOutDate; date = date.AddDays(1))
        //        {
        //            // Count the number of reservations that overlap with this date
        //            int overlappingReservations = hotel.Reservations.Count(reservation =>
        //                reservation.RoomId == room.Id &&
        //                reservation.CheckInDate <= date &&
        //                reservation.CheckOutDate > date &&
        //                !reservation.IsDeleted
        //            );

        //            // Update the available room count for this date
        //            int currentAvailableRoomCount = room.TotalRoomCount - overlappingReservations;

        //            if (currentAvailableRoomCount <= 0)
        //            {
        //                isAvailable = false;
        //                break;
        //            }

        //            // Update the minimum available room count across the range
        //            initialAvailableRoomCount = Math.Min(initialAvailableRoomCount, currentAvailableRoomCount);
        //        }

        //        // Set the final available room count for this room type
        //        room.AvailableRoomCount = initialAvailableRoomCount;

        //        if (!isAvailable)
        //        {
        //            break;
        //        }
        //    }

        //    if (isAvailable)
        //    {
        //        availableHotels.Add(hotel);
        //    }
        //}
        #endregion
        //
        List<AvailableHotelDto?> result = availableHotels.SelectMany(hotel => hotel.Rooms, (hotel, room) => new AvailableHotelDto
        {
            Name = hotel.Name,
            City = hotel.City,
            Town = hotel.Town,
            Rating = hotel.Rating,
            TotalReview = hotel.TotalReview,
            HotelType = hotel.HotelType,
            Rooms = hotel.Rooms.Select(room => new RoomDto
            {
                RoomType = room.RoomType,
                TotalRoomCount = room.TotalRoomCount,
                AvailableRoomCount = room.AvailableRoomCount,
                Price = room.Price
            }).ToList()
        })
        .GroupBy(x => x.Name)
        .Select(g => g.FirstOrDefault())
        .ToList();

        return result;

        //return availableHotels;

    }

    public void Update(Hotel hotel)
    {
        context.Hotels.Update(hotel);
        context.SaveChanges();
    }

    public async Task<List<Hotel>> GetAllHotel()
    {
        return await context.Set<Hotel>().ToListAsync();
    }

    public Task<Hotel?> GetHotelType(HotelType hotelType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Hotel> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Hotel> GetAllWithTracking()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Hotel> Where(Expression<Func<Hotel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Hotel> WhereWithTracking(Expression<Func<Hotel, bool>> expression)
    {
        throw new NotImplementedException();
    }


    public Task<Hotel> GetByExpressionAsync(Expression<Func<Hotel, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Hotel> GetByExpressionWithTrackingAsync(Expression<Func<Hotel, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Hotel> GetFirstAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public bool Any(Expression<Func<Hotel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Hotel GetByExpression(Expression<Func<Hotel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Hotel GetByExpressionWithTracking(Expression<Func<Hotel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Hotel GetFirst()
    {
        throw new NotImplementedException();
    }

    public void Add(Hotel entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(ICollection<Hotel> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


    public void UpdateRange(ICollection<Hotel> entities)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByExpressionAsync(Expression<Func<Hotel, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Hotel entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(ICollection<Hotel> entities)
    {
        throw new NotImplementedException();
    }


}


