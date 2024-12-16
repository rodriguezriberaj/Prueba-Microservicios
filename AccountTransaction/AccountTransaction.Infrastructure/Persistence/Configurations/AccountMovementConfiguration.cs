using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Persistence.Configurations
{
    public class AccountMovementConfiguration : IEntityTypeConfiguration<AccountMovement>
    {
        public void Configure(EntityTypeBuilder<AccountMovement> builder)
        {
            builder.ToTable("AccountMovements");

            builder.HasKey(a => a.AccountMovementId);

            builder.Property(a => a.AccountId)
               .HasColumnName("AccountId")
               .IsRequired();

            builder.HasOne<Account>()
               .WithMany() 
               .HasForeignKey(am => am.AccountId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(am => am.Date)
                   .HasColumnName("Date")
                   .IsRequired();

            builder.OwnsOne(am => am.MovementTypeValue, mt =>
            {
                mt.Property(p => p.Value)
                  .HasColumnName("MovementType")
                  .IsRequired();
            });

            builder.OwnsOne(am => am.Balance, b =>
            {
                b.Property(p => p.Value)
                  .HasColumnName("Balance")
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();
            });

            builder.Property(am => am.Value)
                   .HasColumnName("Value")
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
        }
    }
}
