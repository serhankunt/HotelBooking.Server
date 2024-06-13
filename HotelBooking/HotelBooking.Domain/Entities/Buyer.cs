namespace HotelBooking.Domain.Entities;

public class Buyer
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string IdentityNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string GsmNumber { get; set; } = default!;
    public string RegistrationAddress { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;

}
