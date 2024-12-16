using MediatR;
namespace Application.UseCases
{
    public record RegisterMovementCommand : IRequest
    {
        public required Guid AccountId { get; set; }
        public required decimal Value { get; set; }
    }
}