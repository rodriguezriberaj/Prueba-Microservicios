namespace Shared.Events
{
    public record ClientCreatedEvent(Guid ClientId, string Name) : Event;
}