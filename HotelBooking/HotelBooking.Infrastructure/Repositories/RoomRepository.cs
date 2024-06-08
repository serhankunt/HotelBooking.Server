using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBooking.Infrastructure.Repositories;

public class RoomRepository(ApplicationDbContext context) : IRoomRespository
{
    public async Task CreateAsync(Room room)
    {
        await context.Set<Room>().AddAsync(room);
        await context.SaveChangesAsync();

    }
    public async Task GetHotelTypeAsync(RoomType roomType, CancellationToken cancellationToken)
    {
        await context.Set<Room>().FirstOrDefaultAsync(h => h.RoomType == roomType, cancellationToken);

    }
    public void Add(Room entity)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Room entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(ICollection<Room> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public bool Any(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(Expression<Func<Room, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }



    public void Delete(Room entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByExpressionAsync(Expression<Func<Room, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(ICollection<Room> entities)
    {
        throw new NotImplementedException();
    }

    public Task<Room> FirstOrDefaultAsync(Expression<Func<Room, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Room> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Room> GetAllWithTracking()
    {
        throw new NotImplementedException();
    }

    public Room GetByExpression(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Room> GetByExpressionAsync(Expression<Func<Room, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Room GetByExpressionWithTracking(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Room> GetByExpressionWithTrackingAsync(Expression<Func<Room, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Room GetFirst()
    {
        throw new NotImplementedException();
    }

    public Task<Room> GetFirstAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Room?> GetHotelType(RoomType roomType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }



    public void Update(Room entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(ICollection<Room> entities)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Room> Where(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Room> WhereWithTracking(Expression<Func<Room, bool>> expression)
    {
        throw new NotImplementedException();
    }
}
