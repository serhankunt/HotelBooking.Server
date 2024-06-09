using HotelBooking.Application.Converter;
using HotelBooking.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;
using TS.Result;

namespace HotelBooking.Application.Features.HotelOperation.Create;

public class CreateHotelCommand : IRequest<Result<string>>
{
    public string Name { get; set; } = default!;

    [JsonConverter(typeof(SmartEnumJsonConverter<City>))]
    public City City { get; set; } = default!;

    public string Town { get; set; } = default!;
    [JsonConverter(typeof(SmartEnumJsonConverter<HotelType>))]
    public HotelType HotelType { get; set; } = default!;
    //public List<CreateRoomCommand> Rooms { get; set; } = default!;
}
