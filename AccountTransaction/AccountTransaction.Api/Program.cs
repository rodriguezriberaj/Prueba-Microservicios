using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Repositories;
using Domain.Repositories;
using Api.Endpoints;
using ECommerce.Shared.Infrastructure.RabbitMq;
using Infrastructure.IntegrationEvents;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountTransactionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountMovementRepository, AccountMovementRepository>();

builder.Services.AddRabbitMqEventBus(builder.Configuration)
    .AddRabbitMqSubscriberService(builder.Configuration)
    .AddEventHandler<ClientCreatedEvent, ClientCreatedEventHandler>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Application.ApplicationAssemblyReference).Assembly);
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.RegisterEndpoints();

app.Run();

