using Ardalis.SmartEnum;
using FluentValidation;
using HotelBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;

public class GetAvailableHotelsCommandValidator : AbstractValidator<GetAvailableHotelsCommand>
{
    public GetAvailableHotelsCommandValidator()
    {
        RuleFor(x => x.CheckOutDate)
            .GreaterThan(x => x.CheckInDate)
            .WithMessage($"Check out tarihi Check in tarihinden eski olamaz.");

        RuleFor(x => x.CheckInDate)
            .GreaterThan(DateTime.Now.AddDays(-1))
            .WithMessage($"Check in tarihi {DateTime.Now.ToShortDateString()}'den eski olamaz.");

        RuleFor(x => x.City)
            .Must(y =>
                {
                    return City.TryFromName(y.Name, out var city);
                });
    }
}

