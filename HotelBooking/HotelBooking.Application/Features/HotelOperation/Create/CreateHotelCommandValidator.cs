using FluentValidation;

namespace HotelBooking.Application.Features.HotelOperation.Create;

public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
    {
        RuleFor(p => p.Name)
            .MinimumLength(10)
            .WithMessage("Otel adý en az 10 karakter olmalýdýr");

        RuleFor(p => p.Town)
            .MinimumLength(2)
            .WithMessage("Ýlçe adý en az 2 karakter olmalýdýr");

    }
}
