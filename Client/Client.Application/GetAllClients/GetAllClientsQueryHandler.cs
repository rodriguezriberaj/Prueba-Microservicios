using Application.Shared.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto>>
    {
        private readonly IClientRepository _repository;

        public GetAllClientsQueryHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _repository.GetAllAsync();

            return clients.Select(c => new ClientDto()
            {
                ClientId = c.ClientId,
                Name = c.Name.Value,
                Address = c.Address.Value,
                PhoneNumber = c.PhoneNumber.Value,
                Username = c.Username.Value
            });
        }
    }
}