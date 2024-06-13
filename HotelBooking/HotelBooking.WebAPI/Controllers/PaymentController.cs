using HotelBooking.Application.Features.Payment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentController(CreatePaymentUseCase createPaymentUseCase,
    IMediator mediator) : ControllerBase
{
    [HttpPost]
    public IActionResult CreatePayment([FromBody] PaymentCommand paymentCommand)
    {
        if (paymentCommand == null)
        {
            return BadRequest("Ödeme bilgileri eksik");
        }

        var cancellationToken = HttpContext.RequestAborted;
        var response = createPaymentUseCase.Execute(paymentCommand, cancellationToken);
        return Ok(response);
    }
}
