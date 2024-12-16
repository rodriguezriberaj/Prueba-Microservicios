namespace Application.Shared.DTOs
{
    public record AccountDto
    {
        public Guid AccountId { get;  set; }
        public string AccountNumber { get;  set; }
        public string AccountType { get;  set; }
        public bool Estado { get;  set; }
        public decimal InitialBalance { get;  set; } 
    }
}