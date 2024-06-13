using HotelBooking.Application.Features.Payment;
using HotelBooking.Application.Repositories;
using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using MediatR;
using TS.Result;

namespace HotelBooking.Application.Features.ReservationOperation.Create;

public class CreateReservationCommandHandler(
    IHotelRepository hotelRepository,
    IRoomRespository roomRespository,
    IReservationRepository reservationRepository,
    PaymentCommandHandler paymentCommandHandler) : IRequestHandler<CreateReservationCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.HotelId, cancellationToken);

        var isHotelExist = await hotelRepository.AnyAsync(p => p.Id == request.HotelId);
        if (!isHotelExist)
        {
            return Result<string>.Failure("Otel bulunamadý");
        }

        var room = await roomRespository.GetByIdAsync(request.RoomId);
        if (room == null)
        {
            return Result<string>.Failure("Oda bulunamadý");
        }
        var isRoomExist = await roomRespository.AnyAsync(p => p.Id == request.RoomId);
        if (!isRoomExist)
        {
            return Result<string>.Failure("Oda bulunamadý");
        }

        if (request.CheckOutDate.Date < request.CheckInDate.Date)
        {
            return Result<string>.Failure("Çýkýþ tarihi giriþ tarihinden önce olamaz");
        }

        decimal Price = (decimal)((request.CheckOutDate.Date - request.CheckInDate.Date).Days) * request.AdultGuestCount * 1000;
        int paidMoney;
        var totalPrice = request.AdultGuestCount * Price;
        bool convertToInt = int.TryParse(request.PaymentCommand.PaidPrice, out paidMoney);
        if (!convertToInt)
        {
            return Result<string>.Failure("Ödeme alanýna geçerli deðer giriniz");
        }
        if (totalPrice > paidMoney)
        {
            return Result<string>.Failure("Yetersiz ödeme");
        }


        var paymentResult = await paymentCommandHandler.Handle(request.PaymentCommand, cancellationToken);
        if (!paymentResult.IsSuccessful)
        {
            return Result<string>.Failure("Ödeme baþarýsýz: " + paymentResult.ErrorMessages);
        }



        var reservation = new Reservation
        {
            GuestFullName = request.GuestFullName,
            Email = request.Email,
            HotelId = request.HotelId,
            RoomId = request.RoomId,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            AdultGuestCount = request.AdultGuestCount,
            ChildGuestCount = request.ChildGuestCount,
            Price = Price
        };



        room.AvailableRoomCount -= 1;
        await reservationRepository.AddAsync(reservation);

        string subject = "Rezervasyon Onayý";
        string body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 20px;
            line-height: 1.6;
        }}
        .container {{
            background-color: #f9f9f9;
            padding: 20px;
            border-radius: 10px;
            border: 1px solid #ddd;
        }}
        .header {{
            background-color: #4CAF50;
            color: white;
            padding: 10px;
            border-radius: 10px 10px 0 0;
            text-align: center;
        }}
        .content {{
            padding: 20px;
        }}
        .content b {{
            color: #333;
        }}
        .content p {{
            margin: 10px 0;
        }}
        .content table {{
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }}
        .content table, th, td {{
            border: 1px solid #ddd;
        }}
        .content th, td {{
            padding: 10px;
            text-align: left;
        }}
        .content th {{
            background-color: #f2f2f2;
        }}
        .footer {{
            text-align: center;
            margin: 20px 0 0;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>Rezervasyon Onayý</h2>
        </div>
        <div class='content'>
            <p><b>Sayýn {request.GuestFullName},</b></p>
            <p>Rezervasyon kaydýnýz <b>{hotel!.Name}</b> otelinde baþarýlý bir þekilde oluþturuldu.</p>
            <table>
                 <tr>
                    <th>Þehir</th>
                    <td>{hotel!.City}</td>
                </tr>
                <tr>
                    <th>Oda Türü</th>
                    <td>{room!.RoomType}</td>
                </tr>
                <tr>
                    <th>Giriþ Tarihi</th>
                    <td>{request.CheckInDate.ToShortDateString()}</td>
                </tr>
                <tr>
                    <th>Çýkýþ Tarihi</th>
                    <td>{request.CheckOutDate.ToShortDateString()}</td>
                </tr>
                <tr>
                    <th>Toplam Fiyat</th>
                    <td>{Price:C}</td>
                </tr>
            </table>
            <p>Ýyi günler dileriz.</p>
        </div>
        <div class='footer'>
            <p>HotelBooking Ekibi</p>
        </div>
    </div>
</body>
</html>";


        string emailResponse = await EmailHelper.SendEmailAsync(request.Email, subject, body);

        return Result<string>.Succeed("Rezervasyon kaydýnýz baþarýlý bir þekilde oluþturuldu.");
    }
}
