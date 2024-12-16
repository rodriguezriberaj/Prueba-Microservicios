using System.Text.Json;
using RabbitMQ.Client;

public class RabbitMqEventBus : IEventBus
{
    private const string ExchangeName = "bank-exchange";

    private readonly IRabbitMqConnection _rabbitMqConnection;

    private readonly RabbitMqOptions _options;

    public RabbitMqEventBus(IRabbitMqConnection rabbitMqConnection, RabbitMqOptions options)
    {
        _rabbitMqConnection = rabbitMqConnection;
        _options = options;
    }

    public Task PublishAsync(Event @event)
    {
        var routingKey = @event.GetType().Name;

        using var channel = _rabbitMqConnection.Connection.CreateModel();

        channel.QueueDeclare(queue: _options.QueName, true, false, false, null);

        channel.ExchangeDeclare(
            exchange: ExchangeName,
            type: "fanout",
            durable: true,
            autoDelete: false,
            null);
        
        channel.QueueBind(
            queue: _options.QueName,
            exchange: ExchangeName,
            routingKey: routingKey);

        var body = JsonSerializer.SerializeToUtf8Bytes(@event, @event.GetType());

        channel.BasicPublish(
            exchange: ExchangeName,
            routingKey: routingKey,
            mandatory: false,
            basicProperties: null,
            body: body);

        return Task.CompletedTask;
    }
}