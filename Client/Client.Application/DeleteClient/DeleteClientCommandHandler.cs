using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases
{
    public class DeleteClientCommandHandler :IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientRepository _repository;
         
        public DeleteClientCommandHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(command.clientId);
            
            if (client is null)
            {
                throw new InvalidDataException($"Client with ID {command.clientId} does not exist.");
            }
            
            await _repository.DeleteAsync(client);

            await _repository.SaveChangesAsync();
        }
    }
}