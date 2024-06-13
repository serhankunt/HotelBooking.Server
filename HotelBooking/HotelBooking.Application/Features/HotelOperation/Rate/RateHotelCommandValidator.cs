using FluentValidation;

namespace HotelBooking.Application.Features.HotelOperation.Rate;

public class RateHotelCommandValidator : AbstractValidator<RateHotelCommand>
{
    public RateHotelCommandValidator()
    {
        RuleFor(p => p.Rate)
            .InclusiveBetween(0, 11)
            .WithMessage(p => $"L�tfen ge�erli bir puan giriniz.(0-10). {p.Rate} ge�erli de�il. ");
    }
}
