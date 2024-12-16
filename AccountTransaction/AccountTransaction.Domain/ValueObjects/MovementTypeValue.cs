using Domain.Exceptions;

namespace  Domain.ValueObjects
{
     public enum MovementType
    {
        Withdrawal,
        Deposit
    }

    public record MovementTypeValue
    { 
        public MovementType Value { get; }

        public MovementTypeValue(string MovementType)
        {
            if (!Enum.TryParse(typeof(MovementType), MovementType, true, out var result) || result is not MovementTypeValue)
                throw new NotNegativeAccountBalancedException();

            Value = (MovementType)result!;
        }

        public MovementTypeValue(MovementType gender)
        {
            Value = gender;
        }

        private MovementTypeValue(){}
    }
}