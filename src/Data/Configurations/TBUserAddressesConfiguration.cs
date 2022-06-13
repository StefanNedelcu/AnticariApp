using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBUserAddressesConfiguration : IEntityTypeConfiguration<TBUserAddress>
{
    public void Configure(EntityTypeBuilder<TBUserAddress> entity)
    {
        entity.HasKey(e => e.IdUserAddress)
                .HasName("PRIMARY");

        entity.ToTable("TBUserAddresses");

        entity.HasIndex(e => e.IdCity, "Address_to_City_FK_idx");

        entity.HasIndex(e => e.IdUser, "Address_to_User_FK_idx");

        entity.Property(e => e.StreetName)
            .IsRequired()
            .HasMaxLength(45);

        entity.Property(e => e.ZipCode)
            .IsRequired()
            .HasMaxLength(45);

        entity.HasOne(d => d.IdCityNavigation)
            .WithMany(p => p.TBUserAddresses)
            .HasForeignKey(d => d.IdCity)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Address_to_City_FK");

        entity.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.TBUserAddresses)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Address_to_User_FK");
    }
}
