using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Account
    {
        public Guid AccountId { get; private set; }
        public AccountNumber AccountNumber { get; private set; }
        public AccountTypeValue AccountType { get; private set; }
        public bool Estado { get; private set; }
        public Guid ClientId { get; private set; } 
        public InitialBalance InitialBalance { get; private set; } 

        private Account(){}

        public Account(Guid accountId,string accountNumber, AccountType accountType, Guid clientId)
        {
            AccountId = accountId;
            AccountNumber = new AccountNumber(accountNumber);
            AccountType = new AccountTypeValue(accountType);
            ClientId = clientId;
            InitialBalance = new InitialBalance(0);
            Estado = true;
        }

        public void UpdateBalance(decimal value)
        {
            InitialBalance = new InitialBalance(InitialBalance.Value + value);
        }
    }
}