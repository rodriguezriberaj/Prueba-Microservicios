using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MediatR;
namespace Application.UseCases
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IAccountRepository _repository;

        public CreateAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            var existingAccount = await _repository.GetByIdAsync(command.AccountId);

            if(existingAccount != null){
                throw new InvalidDataException($"Account with ID {command.ClientId} already exist.");
            }

            var account = new Account(
                clientId: command.ClientId,
                accountType: Enum.Parse<AccountType>(command.AccountType, true),
                accountNumber: command.AccountNumber,
                accountId: command.AccountId
            );

            await _repository.AddAsync(account);

            await _repository.SaveChangesAsync();
        }
    }
}