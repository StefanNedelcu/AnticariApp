using AnticariApp.Data.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.TableConfigurations;

public class TBBooksConfiguration : IEntityTypeConfiguration<TBBook>
{
    public void Configure(EntityTypeBuilder<TBBook> entity)
    {
        entity.HasKey(e => e.IdBook)
            .HasName("PRIMARY");

        entity.ToTable("TBBooks");

        entity.HasIndex(e => e.IdAuthor, "Book_to_Author_FK_idx");

        entity.Property(e => e.BookDescription).HasMaxLength(1000);

        entity.Property(e => e.BookTitle)
            .IsRequired()
            .HasMaxLength(45);

        entity.HasOne(d => d.IdAuthorNavigation)
            .WithMany(p => p.TBBooks)
            .HasForeignKey(d => d.IdAuthor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Book_to_Author_FK");
    }
}
