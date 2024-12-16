using Application.Shared.DTOs;
using MediatR;

namespace Application.UseCases
{
    public  record GetAllClientsQuery(): IRequest<IEnumerable<ClientDto>>;
}