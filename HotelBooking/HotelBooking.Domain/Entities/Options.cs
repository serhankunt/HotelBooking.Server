namespace HotelBooking.Domain.Entities;

public class Options
{
    public string ApiKey { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
    public string BaseUrl { get; set; } = default!;
}
