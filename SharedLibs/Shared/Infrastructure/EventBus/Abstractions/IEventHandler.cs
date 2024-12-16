public interface IEventHandler<in TEvent> : IEventHandler
    where TEvent : Event
{
    Task Handle(TEvent @event,IServiceProvider serviceProvider);
    Task IEventHandler.Handle(Event @event, IServiceProvider serviceProvider) => Handle((TEvent)@event, serviceProvider);
}
public interface IEventHandler
{
    Task Handle(Event @event,IServiceProvider serviceProvider);
}