using HotelBooking.Application.Features.Payment;

namespace HotelBooking.Application.Repositories;

public interface IPaymentRepository
{
    PaymentResponse ProcessPayment(PaymentCommand paymentCommand, CancellationToken cancellationToken);
}
