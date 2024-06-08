using HotelBooking.Application.Features.RoomOperation.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]

public class RoomsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode);
    }
}
