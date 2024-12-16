using Application.Shared.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientRepository _repository;

        public GetClientByIdQueryHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.ClientId);

            if (client == null)
            {
                throw new KeyNotFoundException($"Client with ID {request.ClientId} not found.");
            }

            return new ClientDto
            {
                ClientId = client.ClientId,
                Name = client.Name.Value,
                Address = client.Address.Value,
                PhoneNumber = client.PhoneNumber.Value,
                Username = client.Username.Value
            };
        }
    }
}