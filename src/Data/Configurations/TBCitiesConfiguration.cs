﻿using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBCitiesConfiguration : IEntityTypeConfiguration<TBCity>
{
    public void Configure(EntityTypeBuilder<TBCity> entity)
    {
        entity.HasKey(e => e.IdCity)
                .HasName("PRIMARY");

        entity.ToTable("TBCities");

        entity.HasIndex(e => e.IdCountry, "City_to_Country_FK_idx");

        entity.Property(e => e.CityName)
            .IsRequired()
            .HasMaxLength(45);

        entity.HasOne(d => d.Country)
            .WithMany(p => p.TBCities)
            .HasForeignKey(d => d.IdCountry)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("City_to_Country_FK");
    }
}