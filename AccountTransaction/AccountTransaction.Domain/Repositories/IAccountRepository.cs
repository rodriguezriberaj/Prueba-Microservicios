using Domain.Entities;
namespace Domain.Repositories
{
     public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task<Account> GetByIdAsync(Guid accountId);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Account account);
        Task SaveChangesAsync();
    }
}