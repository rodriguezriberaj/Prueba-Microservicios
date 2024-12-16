using Domain.Entities;
namespace Domain.Repositories
{
     public interface IAccountMovementRepository
    {
        Task AddAsync(AccountMovement client);

        Task SaveChangesAsync();
    }
}