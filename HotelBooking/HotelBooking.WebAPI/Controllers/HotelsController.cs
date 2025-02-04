﻿using HotelBooking.Application.Features.HotelOperation.Create;
using HotelBooking.Application.Features.HotelOperation.GetAvailableHotels;
using HotelBooking.Application.Features.HotelOperation.GetAvailableRoomOfHotelsById;
using HotelBooking.Application.Features.HotelOperation.GetById;
using HotelBooking.Application.Features.HotelOperation.GetCapacityById;
using HotelBooking.Application.Features.HotelOperation.Rate;
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

    [HttpPost]
    public async Task<IActionResult> GetById(GetByIdHotelCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetCapacityById(GetCapacityHotelByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAvailableRoomOfHotelsById(GetAvailableRoomOfHotelsByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> RateHotel(RateHotelCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> GetAvailableHotels(GetAvailableHotelsCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }


}
