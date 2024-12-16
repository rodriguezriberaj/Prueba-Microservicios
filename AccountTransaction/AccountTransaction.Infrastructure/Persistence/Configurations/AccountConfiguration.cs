using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.AccountId);

            builder.OwnsOne(a => a.AccountNumber, at =>
            {
                at.Property(p => p.Value)
                  .HasColumnName("AccountNumber")
                  .IsRequired();
            });

            builder.OwnsOne(a => a.AccountType, at =>
            {
                at.Property(p => p.Value)
                  .HasColumnName("AccountType")
                  .IsRequired();
            });

            builder.Property(a => a.Estado)
                .IsRequired();

            builder.HasOne<Client>()
               .WithMany()
               .HasForeignKey(am => am.ClientId)
               .OnDelete(DeleteBehavior.Restrict);

      
            builder.OwnsOne(a => a.InitialBalance, ib =>
            {
                ib.Property(p => p.Value)
                  .HasColumnName("InitialBalance")
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();
            }); 
        }
    }
}