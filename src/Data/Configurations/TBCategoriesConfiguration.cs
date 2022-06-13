using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBCategoriesConfiguration : IEntityTypeConfiguration<TBCategory>
{
    public void Configure(EntityTypeBuilder<TBCategory> entity)
    {
        entity.HasKey(e => e.IdCategory)
                .HasName("PRIMARY");

        entity.ToTable("TBCategories");

        entity.Property(e => e.CategoryDescription).HasMaxLength(1000);

        entity.Property(e => e.CategoryName)
            .IsRequired()
            .HasMaxLength(45);
    }
}
