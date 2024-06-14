using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;

public class GetAvailableHotelsCommandHandler(IHotelRepository hotelRepository) : IRequestHandler<GetAvailableHotelsCommand, Result<List<Hotel>>>
{
    public async Task<Result<List<Hotel>>> Handle(GetAvailableHotelsCommand request, CancellationToken cancellationToken)
    {
        return await hotelRepository
            .GetAvailableHotels(x => x.City == request.City &&
                !x.Reservations
                    .Where(y => request.CheckInDate < y!.CheckOutDate)
                    .Any(y => request.CheckOutDate > y!.CheckInDate),
             cancellationToken);
    }
}

