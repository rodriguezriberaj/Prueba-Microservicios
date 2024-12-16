using System.Text.RegularExpressions;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public record AccountNumber
    {
        public string Value { get; private set; }

        public AccountNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidAccountNumberException(value);

            if (value.Length >= 7)
                throw new InvalidAccountNumberException(value);

            Value = value;
        }

        private AccountNumber(){}
    }
}