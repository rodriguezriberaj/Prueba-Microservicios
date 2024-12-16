namespace Infrastructure.IntegrationEvents
{
    public record ClientCreatedEvent(Guid ClientId, string Name) : Event;
}