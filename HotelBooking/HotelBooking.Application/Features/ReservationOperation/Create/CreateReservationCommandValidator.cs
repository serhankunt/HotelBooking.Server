using FluentValidation;

namespace HotelBooking.Application.Features.ReservationOperation.Create;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(p => p.GuestFullName)
            .NotEmpty()
            .WithMessage("Ad soyad k�sm� bo� olamaz");

        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("L�tfen ge�erli bir mail adresi giriniz");


    }
}
