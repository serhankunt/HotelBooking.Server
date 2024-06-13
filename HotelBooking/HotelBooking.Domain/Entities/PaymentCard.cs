namespace HotelBooking.Domain.Entities;

public class PaymentCard
{
    public string CardHolderName { get; set; } = default!;
    public string CardNumber { get; set; } = default!;
    public string ExpireYear { get; set; } = default!;
    public string ExpireMonth { get; set; } = default!;
    public string Cvc { get; set; } = default!;


}
