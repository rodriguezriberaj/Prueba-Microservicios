
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using MediatR;

namespace Api.Endpoints;

public static class AccountApiEndpoints
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/Cuentas/{accountId}", async(IMediator mediator, Guid accountId) => 
            {
                var account = await mediator.Send(new GetAccountByIdQuery(accountId));

                if(account is null){
                    return Results.NotFound(new { Message = "Account with accountId is not found" });
                }

                return Results.Ok(account);
            });

        routeBuilder.MapPost("/Cuentas",
            async (IMediator mediator, CreateAccountCommand createAccount) =>
            {
                await mediator.Send(createAccount);

                return TypedResults.Created();
            });
        
        routeBuilder.MapDelete("/Cuentas/{accountId}",
            async (IMediator mediator, Guid accountId) =>
            {
                await mediator.Send(new DeleteAccountCommand(accountId));

                return TypedResults.NoContent();
            });

        routeBuilder.MapPost("/Movimientos", async(IMediator mediator, RegisterMovementCommand registerCommand) => 
            {
                await mediator.Send(registerCommand);

                return TypedResults.NoContent();
            });
    }
}