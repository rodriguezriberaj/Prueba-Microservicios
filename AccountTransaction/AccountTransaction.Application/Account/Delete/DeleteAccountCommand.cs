using MediatR;
namespace Application.UseCases
{
    public record DeleteAccountCommand(Guid AccountId) :IRequest;
}