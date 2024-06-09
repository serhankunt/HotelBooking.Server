using FluentValidation;

namespace HotelBooking.Application.Features.ReservationOperation.Create;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(p => p.GuestFullName)
            .NotEmpty()
            .WithMessage("Ad soyad kýsmý boþ olamaz");

        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("Lütfen geçerli bir mail adresi giriniz");


    }
}
