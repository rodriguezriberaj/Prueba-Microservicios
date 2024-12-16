using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases
{
    public class UpdateClientCommandHandler: IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientRepository _repository;

        public UpdateClientCommandHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(command.ClientId);

            if (client is not Client existingClient)
            {
                throw new InvalidDataException($"Client with ID {command.ClientId} does not exist.");
            }
                
            existingClient.UpdateBasicInfo(command.Address, command.PhoneNumber);

            await _repository.UpdateAsync(existingClient);

            await _repository.SaveChangesAsync();
        }
    }
}