using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountMovementRepository : IAccountMovementRepository
    {
        private readonly AccountTransactionDbContext _dbContext;

        public AccountMovementRepository(AccountTransactionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(AccountMovement account)
        {
            await _dbContext.AccountMovements.AddAsync(account);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}