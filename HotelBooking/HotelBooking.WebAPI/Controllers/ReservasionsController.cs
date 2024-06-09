using HotelBooking.Application.Features.ReservationOperation.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ReservasionsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
}
