using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBBookCategoriesConfiguration : IEntityTypeConfiguration<TBBookCategory>
{
    public void Configure(EntityTypeBuilder<TBBookCategory> entity)
    {
        entity.HasKey(e => e.IdBookCategory)
                .HasName("PRIMARY");

        entity.ToTable("TBBookCategories");

        entity.HasIndex(e => e.IdBook, "BookCategory_to_Book_FK_idx");

        entity.HasIndex(e => e.IdCategory, "BookCategory_to_Category_FK_idx");

        entity.HasOne(d => d.Book)
            .WithMany(p => p.TBBookCategories)
            .HasForeignKey(d => d.IdBook)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("BookCategory_to_Book_FK");

        entity.HasOne(d => d.Category)
            .WithMany(p => p.TBBookCategories)
            .HasForeignKey(d => d.IdCategory)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("BookCategory_to_Category_FK");
    }
}
