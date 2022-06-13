using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBCountriesConfiguration : IEntityTypeConfiguration<TBCountry>
{
    public void Configure(EntityTypeBuilder<TBCountry> entity)
    {
        entity.HasKey(e => e.IdCountry)
                .HasName("PRIMARY");

        entity.ToTable("TBCountries");

        entity.Property(e => e.CountryName)
            .IsRequired()
            .HasMaxLength(45);
    }
}
