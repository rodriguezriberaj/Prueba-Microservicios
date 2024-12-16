public interface IEventBus
{
    Task PublishAsync(Event @event);
}