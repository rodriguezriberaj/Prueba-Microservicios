using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MediatR;
namespace Application.UseCases
{
    public class RegisterMovementCommandHandler : IRequestHandler<RegisterMovementCommand>
    {
        private readonly IAccountMovementRepository _movementRepository;
        private readonly IAccountRepository _accountRepository;

        public RegisterMovementCommandHandler(IAccountMovementRepository movementRepository, IAccountRepository accountRepository )
        {
            _movementRepository = movementRepository;
            _accountRepository = accountRepository;
        }

        public async Task Handle(RegisterMovementCommand command, CancellationToken cancellationToken)
        {
            if(command.Value == 0 )
            {
                throw new InvalidDataException("Movement with zero value cannot be registered.");
            }

            var existingAccount = await _accountRepository.GetByIdAsync(command.AccountId);

            if(existingAccount is null)
            {
                throw new InvalidDataException($"Account with ID {command.AccountId} not exist.");
            }

            existingAccount.UpdateBalance(command.Value);

            var movementType = command.Value > 0 ? MovementType.Deposit : MovementType.Withdrawal;
           
            var newMovement = new AccountMovement(
                new Guid(), 
                existingAccount.AccountId, 
                DateTime.Now, movementType,
                existingAccount.InitialBalance.Value, 
                command.Value );
            
            await _movementRepository.AddAsync(newMovement);

            await _movementRepository.SaveChangesAsync();
        }
    }
}