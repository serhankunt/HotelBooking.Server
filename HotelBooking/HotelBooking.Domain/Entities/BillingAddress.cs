namespace HotelBooking.Domain.Entities;

public class BillingAddress
{
    public string ContactName { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
}
