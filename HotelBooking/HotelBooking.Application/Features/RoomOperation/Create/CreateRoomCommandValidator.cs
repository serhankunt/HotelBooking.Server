using FluentValidation;

namespace HotelBooking.Application.Features.RoomOperation.Create;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(1);
    }
}
