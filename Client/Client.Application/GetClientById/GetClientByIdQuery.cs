using Application.Shared.DTOs;
using MediatR;

namespace Application.UseCases
{
    public record GetClientByIdQuery(Guid ClientId) : IRequest<ClientDto>;
}