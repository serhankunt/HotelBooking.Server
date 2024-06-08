using HotelBooking.Application.Features.HotelOperation.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class HotelsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);


    }
}
