using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBooking.Infrastructure.Repositories;

public class ReservationRepository(ApplicationDbContext context) : IReservationRepository
{
    public async Task<IEnumerable<Reservation>> GetExpiredReservationsAsync(DateTime currentDate)
    {
        return await context.Reservations
            .Where(r => r.CheckOutDate < currentDate && r.IsCompleted == false && r.IsDeleted == false)
            .ToListAsync();
    }
    public async Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Reservation>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task CreateAsync(Reservation reservation)
    {
        await context.Set<Reservation>().AddAsync(reservation);
        await context.SaveChangesAsync();
    }
    public async Task AddAsync(Reservation entity, CancellationToken cancellationToken = default)
    {

        await context.Set<Reservation>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateAsync(Reservation reservation)
    {
        context.Reservations.Update(reservation);
        await context.SaveChangesAsync();
    }
    public void Update(Reservation reservation)
    {
        context.Reservations.Update(reservation);
        context.SaveChanges();
    }

    public async Task CreateAsync(Reservation reservation, CancellationToken cancellationToken)
    {
        await context.Set<Reservation>().AddAsync(reservation, cancellationToken);
        await context.SaveChangesAsync();
    }
    public async Task<bool> AnyAsync(Expression<Func<Reservation, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await context.Set<Reservation>().AnyAsync(expression, cancellationToken);
    }
    public async Task<Reservation?> FirstOrDefaultAsync(Expression<Func<Reservation, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
    {
        return await context.Set<Reservation>().FirstOrDefaultAsync(expression, cancellationToken);
    }
    public Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Reservation> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Reservation> GetAllWithTracking()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Reservation> Where(Expression<Func<Reservation, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Reservation> WhereWithTracking(Expression<Func<Reservation, bool>> expression)
    {
        throw new NotImplementedException();
    }



    public Task<Reservation> GetByExpressionAsync(Expression<Func<Reservation, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Reservation> GetByExpressionWithTrackingAsync(Expression<Func<Reservation, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Reservation> GetFirstAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }



    public bool Any(Expression<Func<Reservation, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Reservation GetByExpression(Expression<Func<Reservation, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Reservation GetByExpressionWithTracking(Expression<Func<Reservation, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Reservation GetFirst()
    {
        throw new NotImplementedException();
    }


    public void Add(Reservation entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(ICollection<Reservation> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }



    public void UpdateRange(ICollection<Reservation> entities)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByExpressionAsync(Expression<Func<Reservation, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Reservation entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(ICollection<Reservation> entities)
    {
        throw new NotImplementedException();
    }


}
