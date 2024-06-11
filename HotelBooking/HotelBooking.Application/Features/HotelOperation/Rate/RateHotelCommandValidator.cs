using FluentValidation;

namespace HotelBooking.Application.Features.HotelOperation.Rate;

public class RateHotelCommandValidator : AbstractValidator<RateHotelCommand>
{
    public RateHotelCommandValidator()
    {
        RuleFor(p => p.Rate)
            .ExclusiveBetween(0, 10)
            .WithMessage(p => $"Lütfen geçerli bir puan giriniz.(0-10). {p.Rate} geçerli deðil. ");
    }
}
