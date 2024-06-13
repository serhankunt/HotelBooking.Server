using HotelBooking.Application.Features.Payment;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentController(
    CreatePaymentUseCase createPaymentUseCase) : ControllerBase
{
    [HttpPost]
    public IActionResult CreatePayment([FromBody] PaymentCommand paymentCommand)
    {
        if (paymentCommand == null)
        {
            return BadRequest("Ödeme bilgileri eksik");
        }
        try
        {
            var cancellationToken = HttpContext.RequestAborted;
            var response = createPaymentUseCase.Execute(paymentCommand, cancellationToken);
            if (response.Status == "success")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Bir hatayla karşılaşıldı");
            }

        }
        catch (Exception ex)
        {
            // Log the error
            Console.WriteLine($"An error occurred: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }

        //var cancellationToken = HttpContext.RequestAborted;
        //var response = createPaymentUseCase.Execute(paymentCommand, cancellationToken);
        //return Ok(response);
    }
}
