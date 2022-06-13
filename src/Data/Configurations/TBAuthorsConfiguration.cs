using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBAuthorsConfiguration : IEntityTypeConfiguration<TBAuthor>
{
    public void Configure(EntityTypeBuilder<TBAuthor> entity)
    {
        entity.HasKey(e => e.IdAuthor)
                .HasName("PRIMARY");

        entity.ToTable("TBAuthors");

        entity.Property(e => e.AuthorDescription).HasMaxLength(1000);

        entity.Property(e => e.AuthorName)
            .IsRequired()
            .HasMaxLength(45);
    }
}
