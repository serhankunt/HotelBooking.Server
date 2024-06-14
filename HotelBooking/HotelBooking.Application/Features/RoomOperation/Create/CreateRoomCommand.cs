
using HotelBooking.Application.Converter;
using HotelBooking.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;
using TS.Result;

namespace HotelBooking.Application.Features.RoomOperation.Create;


public class CreateRoomCommand : IRequest<Result<string>>
{
    [JsonConverter(typeof(SmartEnumJsonConverter<RoomType>))]
    public RoomType RoomType { get; set; } = default!;
    public int Quantity { get; set; }
    public Guid HotelId { get; set; }
    public decimal Price { get; set; }
}