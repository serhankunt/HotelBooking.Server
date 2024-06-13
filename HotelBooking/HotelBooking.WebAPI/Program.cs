using DefaultCorsPolicyNugetPackage;
using Hangfire;
using HotelBooking.Application;
using HotelBooking.Application.Converter;
using HotelBooking.Application.Features.Payment;
using HotelBooking.Application.Features.ReservationOperation.Check;
using HotelBooking.Application.Repositories;
using HotelBooking.Domain.Enums;
using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Repositories;
using HotelBooking.WebAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(cfr =>
{
    cfr.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().SetIsOriginAllowed(policy => true);
    });
});


builder.Services.AddScoped<CreatePaymentUseCase>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRespository, RoomRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new SmartEnumJsonConverter<City>());
        options.SerializerSettings.Converters.Add(new SmartEnumJsonConverter<HotelType>());
        options.SerializerSettings.Converters.Add(new SmartEnumJsonConverter<RoomType>());
    }); ;
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});

builder.Services.AddHangfire(config => config.UseSqlServerStorage("Data Source=DESKTOP-L1BOF4K\\SQLEXPRESS;Initial Catalog=HotelBookingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddHangfireServer();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHangfireDashboard();


app.UseCors();

app.UseExceptionHandler();

app.MapControllers();

var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();
recurringJobManager.AddOrUpdate<ReservationCheckJob>(
    "CheckExpiredReservations",
    job => job.CheckExpiredReservations(),
    Cron.Hourly
);
ExtensionsMiddleware.CreateFirstUser(app);

app.Run();
