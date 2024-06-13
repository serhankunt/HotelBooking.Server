using HotelBooking.Application.Features.Payment;
using HotelBooking.Application.Repositories;
using Iyzipay.Request;


namespace HotelBooking.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    public PaymentResponse ProcessPayment(PaymentCommand paymentRequest, CancellationToken cancellationToken)
    {

        var command = new CreatePaymentRequest
        {
            Locale = paymentRequest.Locale,
            Price = paymentRequest.Price,
            PaidPrice = paymentRequest.PaidPrice,
            Currency = paymentRequest.Currency,
            Installment = paymentRequest.Installment,
            BasketId = paymentRequest.BasketId,
            PaymentCard = new Iyzipay.Model.PaymentCard
            {
                CardHolderName = paymentRequest.PaymentCard.CardHolderName,
                CardNumber = paymentRequest.PaymentCard.CardNumber,
                ExpireMonth = paymentRequest.PaymentCard.ExpireMonth,
                ExpireYear = paymentRequest.PaymentCard.ExpireYear,
                Cvc = paymentRequest.PaymentCard.Cvc,
            },
            Buyer = new Iyzipay.Model.Buyer
            {
                Id = paymentRequest.Buyer.Id,
                Name = paymentRequest.Buyer.Name,
                Surname = paymentRequest.Buyer.Surname,
                GsmNumber = paymentRequest.Buyer.GsmNumber,
                Email = paymentRequest.Buyer.Email,
                IdentityNumber = paymentRequest.Buyer.IdentityNumber,
                RegistrationAddress = paymentRequest.Buyer.RegistrationAddress,
                City = paymentRequest.Buyer.City,
                Country = paymentRequest.Buyer.Country,

            },
            BillingAddress = new Iyzipay.Model.Address
            {
                ContactName = paymentRequest.BillingAddress.ContactName,
                City = paymentRequest.BillingAddress.City,
                Country = paymentRequest.BillingAddress.Country,
                Description = paymentRequest.BillingAddress.Description,
                ZipCode = paymentRequest.BillingAddress.ZipCode
            },
            BasketItems = paymentRequest.BasketItems.Select(basketItem => new Iyzipay.Model.BasketItem
            {
                Id = basketItem.Id,
                Name = basketItem.Name,
                Category1 = basketItem.Category1,
                Category2 = basketItem.Category2,
                ItemType = basketItem.ItemType,
                Price = basketItem.Price
            }).ToList()
        };

        var options = new Iyzipay.Options
        {
            ApiKey = "sandbox-MBmzWVOeil9arc1EVT1PLGRh07ARuxGr",
            SecretKey = "DW8050suGcchWnAoveQoglj4YfUq7NHi",
            BaseUrl = "https://sandbox-api.iyzipay.com"
        };


        var payment = Iyzipay.Model.Payment.Create(command, options);

        if (payment.Status == "success")
        {
            return new PaymentResponse(payment.Status, payment.PaymentId);
        }
        else
        {
            Console.WriteLine($"Payment failed: {payment.ErrorMessage}");
            return new PaymentResponse(payment.Status, null);
        }


    }

}
