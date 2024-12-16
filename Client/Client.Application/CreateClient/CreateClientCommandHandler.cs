using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MediatR;
using Shared.Events;

namespace Application.UseCases
{
    public class CreateClientCommandHandler: IRequestHandler<CreateClientCommand>
    {
        private readonly IClientRepository _repository;
        private readonly IEventBus _eventBus;

        public CreateClientCommandHandler(IClientRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public async Task Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var existingClient = await _repository.GetByIdAsync(command.ClientId);

            if(existingClient != null){
                throw new InvalidDataException($"Client with ID {command.ClientId} already exist.");
            }

            var client = new Client(
                name: command.Name,
                gender: Enum.Parse<Gender>(command.Gender, true),
                age: command.Age,
                identification: command.Identification,
                address: command.Address,
                phoneNumber: command.PhoneNumber,
                clientId: command.ClientId,
                username: command.Username,
                password: command.Password
            );

            await _repository.AddAsync(client);

            await _repository.SaveChangesAsync();

            await _eventBus.PublishAsync(new ClientCreatedEvent(command.ClientId, command.Name));
        }
    }
}