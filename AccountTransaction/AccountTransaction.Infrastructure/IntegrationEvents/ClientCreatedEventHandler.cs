using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IntegrationEvents
{
    public  class ClientCreatedEventHandler : IEventHandler<ClientCreatedEvent>
    {
        public ClientCreatedEventHandler()
        {
        }

        public Task Handle(ClientCreatedEvent @event, IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AccountTransactionDbContext>();

            dbContext.Clients.AddAsync(new Client(@event.ClientId, @event.Name));

            dbContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}