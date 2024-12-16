using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.ClientId)
               .HasColumnName("ClientId")
               .IsRequired();
            
            builder.OwnsOne(c => c.Username, username =>
            {
                username.Property(u => u.Value)
                    .HasColumnName("Username")
                    .IsRequired()
                    .HasMaxLength(50);
            });

            builder.OwnsOne(c => c.Password, password =>
            {
                password.Property(p => p.Value)
                    .HasColumnName("Password")
                    .IsRequired()
                    .HasMaxLength(200);
            });

        }
    }
}