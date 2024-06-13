using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.Payment;

public class PaymentCommand : IRequest<Result<string>>
{
    public string Locale { get; set; } = default!;
    public string Price { get; set; } = default!;
    public string PaidPrice { get; set; } = default!;
    public string Currency { get; set; } = default!;
    public int Installment { get; set; }
    public string BasketId { get; set; } = default!;
    public PaymentCard PaymentCard { get; set; } = default!;
    public Buyer Buyer { get; set; } = default!;
    public BillingAddress BillingAddress { get; set; } = default!;
    public List<BasketItem> BasketItems { get; set; } = default!;
}
