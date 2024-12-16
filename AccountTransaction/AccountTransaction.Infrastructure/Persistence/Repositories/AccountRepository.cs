using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountTransactionDbContext _dbContext;

        public AccountRepository(AccountTransactionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
        }

        public async Task<Account?> GetByIdAsync(Guid accountId)
        {
            return await _dbContext.Accounts
                .FirstOrDefaultAsync(c => c.AccountId == accountId);
        }

        public async Task UpdateAsync(Account account)
        {
            _dbContext.Accounts.Update(account);
        }

        public async Task DeleteAsync(Account account)
        {
            _dbContext.Accounts.Remove(account);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}