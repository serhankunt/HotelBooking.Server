using Iyzipay.Model;

namespace HotelBooking.Domain.Entities;

public class BasketItem
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Category1 { get; set; } = default!;
    public string Category2 { get; set; } = default!;
    public string ItemType { get; set; } = BasketItemType.VIRTUAL.ToString();
    public string Price { get; set; } = default!;
}
