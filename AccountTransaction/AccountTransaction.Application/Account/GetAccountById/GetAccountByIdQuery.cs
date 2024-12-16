using Application.Shared.DTOs;
using MediatR;

namespace Application.UseCases
{
    public record GetAccountByIdQuery(Guid AccountId) : IRequest<AccountDto>;
}