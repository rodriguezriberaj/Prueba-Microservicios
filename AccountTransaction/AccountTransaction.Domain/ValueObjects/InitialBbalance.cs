using Domain.Exceptions;

namespace  Domain.ValueObjects
{
    public record InitialBalance
    {
         public decimal Value { get;}

         public InitialBalance(decimal value)
         {
            if(value < 0){
                throw new NotNegativeInitialBalanceException();
            }
            Value = value;
         }

         private InitialBalance(){}
    }
}