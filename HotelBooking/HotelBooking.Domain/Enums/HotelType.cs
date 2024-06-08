using Ardalis.SmartEnum;

namespace HotelBooking.Domain.Enums;

public class HotelType : SmartEnum<HotelType>
{
    public static readonly HotelType HerSeyDahil = new HotelType("Her Þey Dahil", 1);
    public static readonly HotelType Villa = new HotelType("Villa", 2);
    public static readonly HotelType Spa = new HotelType("Spa", 3);
    public static readonly HotelType TatilKoyu = new HotelType("Tatil Köyü", 4);
    public static readonly HotelType Apart = new HotelType("Apart", 5);


    private HotelType(string name, int value) : base(name, value)
    {

    }
}
