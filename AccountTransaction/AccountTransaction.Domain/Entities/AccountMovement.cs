using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class AccountMovement
    {
        public Guid AccountMovementId { get; private set; }
        public Guid AccountId { get; private set; }
        public DateTime Date { get; private set; }
        public MovementTypeValue MovementTypeValue { get; private set; }
        public AccountBalance Balance { get; private set; }
        public decimal Value { get; private set; }

        private AccountMovement(){} 

        public AccountMovement(
            Guid accountMovementId,
            Guid accountId,
            DateTime date, 
            MovementType movementType, 
            decimal balance, 
            decimal value)
        {
            AccountMovementId = accountMovementId;
            AccountId = accountId;
            Date = date;
            MovementTypeValue = new MovementTypeValue(movementType);
            Balance = new AccountBalance(balance);
            Value = value;
        }
    }
}
