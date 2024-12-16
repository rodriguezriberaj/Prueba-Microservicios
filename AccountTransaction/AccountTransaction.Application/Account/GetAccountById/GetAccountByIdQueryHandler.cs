using Application.Shared.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
    {
        private readonly IAccountRepository _repository;

        public GetAccountByIdQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(request.AccountId);

            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID {request.AccountId} not found.");
            }

            return new AccountDto
            {
                AccountId = account.AccountId,
                AccountNumber = account.AccountNumber.Value,
                AccountType = account.AccountType.ToString(),
                Estado = account.Estado,
                InitialBalance = account.InitialBalance.Value
            };
        }
    }
}