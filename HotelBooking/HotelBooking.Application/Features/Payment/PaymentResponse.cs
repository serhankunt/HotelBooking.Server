namespace HotelBooking.Application.Features.Payment;

public class PaymentResponse
{
    public string Status { get; set; } = default!;
    public string TransactionId { get; set; } = default!;

    public PaymentResponse(string status, string transactionId)
    {
        Status = status;
        TransactionId = transactionId;
    }
}
