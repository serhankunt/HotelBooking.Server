using HotelBooking.Application.Repositories;
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

    public Task<Hotel> FirstOrDefaultAsync(Expression<Func<Hotel, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
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

    public void Update(Hotel entity)
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


