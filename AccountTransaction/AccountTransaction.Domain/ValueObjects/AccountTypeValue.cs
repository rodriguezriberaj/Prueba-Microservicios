using Domain.Exceptions;

namespace  Domain.ValueObjects
{
     public enum AccountType
    {
        Savings ,
        Checking
    }

    public record AccountTypeValue
    { 
        public AccountType Value { get; }

        public AccountTypeValue(string accountType)
        {
            if (!Enum.TryParse(typeof(AccountType), accountType, true, out var result) || result is not AccountType)
                throw new InvalidAccountTypeException(accountType);

            Value = (AccountType)result!;
        }

        public AccountTypeValue(AccountType gender)
        {
            Value = gender;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        private AccountTypeValue(){}
    }
}