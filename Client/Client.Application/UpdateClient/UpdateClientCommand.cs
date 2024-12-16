using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.UseCases
{
    public record UpdateClientCommand : IRequest
    {
         public Guid ClientId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}