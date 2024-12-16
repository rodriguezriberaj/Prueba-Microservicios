
namespace Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message) { }
    }

    public class InvalidAccountTypeException : DomainException
    {
        public InvalidAccountTypeException(string accountType)
            : base($"The Account Type '{accountType}' is invalid.") { }
    }

    public class InvalidAccountNumberException : DomainException
    {
        public InvalidAccountNumberException(string accountNumber)
            : base($"The Account Number '{accountNumber}' is invalid. It must be a 6-digit numeric value or less.") { }
    }

    public class NotNegativeInitialBalanceException : DomainException
    {
        public NotNegativeInitialBalanceException()
            : base($"The Initial Balance cannot be negative.") { }
    }

    public class InvalidClientIdException : DomainException
    {
        public InvalidClientIdException(Guid value)
            : base($"The ClienteId '{value}' is invalid. It cannot be empty.") { }
    }

    public class InvalidAccountMovementIdException : DomainException
    {
        public InvalidAccountMovementIdException(Guid value)
            : base($"The ClienteId '{value}' is invalid. It cannot be empty.") { }
    }

    public class InvalidAccountIdException : DomainException
    {
        public InvalidAccountIdException(Guid value)
            : base($"The ClienteId '{value}' is invalid. It cannot be empty.") { }
    }

    public class InvalidMovementTypeException : DomainException
    {
        public InvalidMovementTypeException(string value)
            : base($"The Movement Type '{value}' is invalid.") { }
    }

    public class NotNegativeAccountBalancedException : DomainException
    {
        public NotNegativeAccountBalancedException()
            : base("The account balance cannot be negative.") { }
    }
}