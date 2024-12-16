using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AccountTransactionDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<AccountMovement> AccountMovements { get; set; } 
        public DbSet<Account> Accounts { get; set; } 
        public DbSet<AccountMovement> Persons { get; set; } 

        public AccountTransactionDbContext(DbContextOptions<AccountTransactionDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountMovementConfiguration());
        }
    }
}