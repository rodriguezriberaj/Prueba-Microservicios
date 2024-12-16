using RabbitMQ.Client;

public interface IRabbitMqConnection
{
    IConnection Connection { get; }
}