using MediatR;
namespace Application.UseCases
{
    public record CreateAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public Guid ClientId { get; set; } 
    }
}