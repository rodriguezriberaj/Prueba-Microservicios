using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client.Events;

public class RabbitMqHostedService : IHostedService
{
    private const string ExchangeName = "bank-exchange";

    private readonly IServiceProvider _serviceProvider;
    private readonly EventHandlerRegistration _handlerRegistrations;
    private readonly EventBusOptions _eventBusOptions;

    public RabbitMqHostedService(IServiceProvider serviceProvider,
        IOptions<EventHandlerRegistration> handlerRegistrations,
        IOptions<EventBusOptions> eventBusOptions)
    {
        _serviceProvider = serviceProvider;
        _handlerRegistrations = handlerRegistrations.Value;
        _eventBusOptions = eventBusOptions.Value;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {

        var rabbitMQConnection = _serviceProvider.GetRequiredService<IRabbitMqConnection>();
        
        var channel = rabbitMQConnection.Connection.CreateModel();
        
        channel.ExchangeDeclare(
            exchange: ExchangeName,
            type: "fanout",
            durable: true,
            autoDelete: false,
            null);
            
        channel.QueueDeclare(
            queue: _eventBusOptions.QueueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
            
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += OnMessageReceived;
        
        channel.BasicConsume(
            queue: _eventBusOptions.QueueName,
            autoAck: true,
            consumer: consumer,
            consumerTag: string.Empty,
            noLocal: false,
            exclusive: false,
            arguments: null);
            
        channel.QueueBind(
            queue: _eventBusOptions.QueueName,
            exchange: ExchangeName,
            routingKey: "ClientCreatedEvent",
            arguments: null);
        
        
        return Task.CompletedTask;
    }

    private void OnMessageReceived(object? sender, BasicDeliverEventArgs eventArgs)
    {
        var eventName = eventArgs.RoutingKey;
        var message = Encoding.UTF8.GetString(eventArgs.Body.Span);
        
        using var scope = _serviceProvider.CreateScope();
        
        if (!_handlerRegistrations.EventTypes.TryGetValue(eventName, out var eventType))
        {
            return;
        }
        
        var @event = JsonSerializer.Deserialize(message, eventType) as Event;
        foreach (var handler in 
            scope.ServiceProvider.GetKeyedServices<IEventHandler>(eventType))
        {
            handler.Handle(@event, scope.ServiceProvider);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
         return Task.CompletedTask;
    }
}