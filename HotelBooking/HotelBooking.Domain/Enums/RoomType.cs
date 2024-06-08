using Ardalis.SmartEnum;

namespace HotelBooking.Domain.Enums;

public class RoomType : SmartEnum<RoomType>
{
    public static readonly RoomType Fýrsat = new RoomType("Fýrsat Odasý", 1);
    public static readonly RoomType Standart = new RoomType("Standart Oda", 2);
    public static readonly RoomType Suite = new RoomType("Suite", 3);
    public static readonly RoomType Aile = new RoomType("Aile", 4);

    private RoomType(string name, int value) : base(name, value)
    {

    }

}
