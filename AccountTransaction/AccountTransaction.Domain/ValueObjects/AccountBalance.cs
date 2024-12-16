using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class AccountBalance
    {
        public decimal Value { get; private set; }

        public AccountBalance(decimal value)
        {
            if (value < 0)
                throw new NotNegativeAccountBalancedException();

            Value = value;
        }

        private AccountBalance(){}
    }
}