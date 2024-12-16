using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.UseCases
{
    public record CreateClientCommand :  IRequest
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}