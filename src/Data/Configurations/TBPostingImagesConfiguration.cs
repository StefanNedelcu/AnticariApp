using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBPostingImagesConfiguration : IEntityTypeConfiguration<TBPostingImage>
{
    public void Configure(EntityTypeBuilder<TBPostingImage> entity)
    {
        entity.HasKey(e => e.IdPostingImage)
                .HasName("PRIMARY");

        entity.ToTable("TBPostingImages");

        entity.HasIndex(e => e.IdPosting, "PostingImage_to_Posting_FK_idx");

        entity.Property(e => e.ImgSrc)
            .IsRequired()
            .HasMaxLength(255);

        entity.HasOne(d => d.IdPostingNavigation)
            .WithMany(p => p.TBPostingImages)
            .HasForeignKey(d => d.IdPosting)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("PostingImage_to_Posting_FK");
    }
}
