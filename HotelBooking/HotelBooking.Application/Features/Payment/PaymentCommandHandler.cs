using HotelBooking.Application.Repositories;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.Payment;

public class PaymentCommandHandler(IPaymentRepository paymentRepository) : IRequestHandler<PaymentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(PaymentCommand request, CancellationToken cancellationToken)
    {
        var paymentResponse = paymentRepository.ProcessPayment(request, cancellationToken);
        var transactionId = paymentResponse.TransactionId;
        if (paymentResponse.Status == "success")
        {
            return Result<string>.Succeed(transactionId);
        }
        else
        {
            return Result<string>.Failure("Payment failed");
        }
    }
}

