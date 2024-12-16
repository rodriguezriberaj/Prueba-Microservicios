using MediatR;

namespace Application.UseCases
{
    public record DeleteClientCommand(Guid clientId) :IRequest;
}