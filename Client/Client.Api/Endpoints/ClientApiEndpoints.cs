
using Application.Shared.DTOs;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using MediatR;

namespace Api.Endpoints;

public static class ClientApiEndpoints
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/Clientes",  async (IMediator mediator) => 
            {
                return await mediator.Send(new GetAllClientsQuery());
            });

        routeBuilder.MapGet("/Clientes/{clientId}", async(IMediator mediator, Guid clientId) => 
            {
                var client = await mediator.Send(new GetClientByIdQuery(clientId));

                if(client is null){
                    return Results.NotFound(new { Message = "Client not found" });
                }

                return Results.Ok(client);
            });

        routeBuilder.MapPost("/Clientes",
            async (IMediator mediator, CreateClientCommand createClient) =>
            {
                await mediator.Send(createClient);

                return TypedResults.Created();
            });

        routeBuilder.MapPut("/Clientes",
            async (IMediator mediator, UpdateClientCommand updateClient) =>
            {
                await mediator.Send(updateClient);

                return TypedResults.NoContent();
            });
        
        routeBuilder.MapDelete("/Clientes/{clientId}",
            async (IMediator mediator, Guid clientId) =>
            {
                await mediator.Send(new DeleteClientCommand(clientId));

                return TypedResults.NoContent();
            });
    }
}