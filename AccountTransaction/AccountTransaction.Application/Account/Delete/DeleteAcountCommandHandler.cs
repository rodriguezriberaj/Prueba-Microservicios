using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MediatR;
namespace Application.UseCases
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountRepository _repository;

        public DeleteAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(command.AccountId);
            
            if (account is null)
            {
                throw new InvalidDataException($"Account with ID {command.AccountId} does not exist.");
            }
            
            await _repository.DeleteAsync(account);

            await _repository.SaveChangesAsync();
        }
    }
}