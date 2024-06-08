using FluentValidation;

namespace HotelBooking.Application.Features.HotelOperation.Create;

public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
    {
        RuleFor(p => p.Name)
            .MinimumLength(10)
            .WithMessage("Otel ad� en az 10 karakter olmal�d�r");

        RuleFor(p => p.Town)
            .MinimumLength(2)
            .WithMessage("�l�e ad� en az 2 karakter olmal�d�r");

    }
}
