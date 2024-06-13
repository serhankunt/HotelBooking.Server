using FluentValidation;
using HotelBooking.Application.Behaviors;
using HotelBooking.Application.Features.Payment;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddScoped<PaymentCommandHandler>();

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}
