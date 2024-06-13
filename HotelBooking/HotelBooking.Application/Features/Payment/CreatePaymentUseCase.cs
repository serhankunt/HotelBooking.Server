using HotelBooking.Application.Repositories;

namespace HotelBooking.Application.Features.Payment;

public class CreatePaymentUseCase(IPaymentRepository paymentRepository)
{
    public PaymentResponse Execute(PaymentCommand paymentCommand, CancellationToken cancellationToken)
    {
        return paymentRepository.ProcessPayment(paymentCommand, cancellationToken);
    }
}
