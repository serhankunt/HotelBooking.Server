using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using MediatR;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;

public class GetAvailableHotelsCommand : IRequest<Result<List<Hotel>>>
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public City City { get; set; } = default!;
}

