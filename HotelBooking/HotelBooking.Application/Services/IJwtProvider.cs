using HotelBooking.Application.Features.Auth.Login;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Services;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}
