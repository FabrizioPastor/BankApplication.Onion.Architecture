using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class ClienteConfig : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .HasMaxLength(80)
            .IsRequired();
        
        builder.Property(p => p.LastName)
            .HasMaxLength(80)
            .IsRequired();
        
        builder.Property(p => p.BirthDay)
            .IsRequired();
        
        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(9)
            .IsRequired();

        builder.Property(p => p.Email)
            .HasMaxLength(100);
        
        builder.Property(p => p.Direction)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(p => p.CreatedBy)
            .HasMaxLength(30);

        builder.Property(p => p.LastModifiedBy)
            .HasMaxLength(30);
    }
}