using AnticariApp.Data.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.TableConfigurations;

public class TBPostingsConfiguration : IEntityTypeConfiguration<TBPosting>
{
    public void Configure(EntityTypeBuilder<TBPosting> entity)
    {
        entity.HasKey(e => e.IdPosting)
                .HasName("PRIMARY");

        entity.ToTable("TBPostings");

        entity.HasIndex(e => e.IdBook, "Posting_to_Book_FK_idx");

        entity.HasIndex(e => e.IdOwnerUser, "Posting_to_Owner_FK_idx");

        entity.Property(e => e.PostingDescription).HasMaxLength(1000);

        entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

        entity.HasOne(d => d.IdBookNavigation)
            .WithMany(p => p.TBPostings)
            .HasForeignKey(d => d.IdBook)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Posting_to_Book_FK");

        entity.HasOne(d => d.IdOwnerUserNavigation)
            .WithMany(p => p.TBPostings)
            .HasForeignKey(d => d.IdOwnerUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Posting_to_Owner_FK");
    }
}
