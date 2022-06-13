using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBUsersConfiguration : IEntityTypeConfiguration<TBUser>
{
    public void Configure(EntityTypeBuilder<TBUser> entity)
    {
        entity.HasKey(e => e.IdUser)
                .HasName("PRIMARY");

        entity.ToTable("TBUsers");

        entity.HasIndex(e => e.Email, "Email_UNIQUE")
            .IsUnique();

        entity.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(45);

        entity.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(45);

        entity.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(45);

        entity.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(255);
    }
}
