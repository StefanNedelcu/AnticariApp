using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBExchangeOffersConfiguration : IEntityTypeConfiguration<TBExchangeOffer>
{
    public void Configure(EntityTypeBuilder<TBExchangeOffer> entity)
    {
        entity.HasKey(e => e.IdExchangeOffer)
                .HasName("PRIMARY");

        entity.ToTable("TBExchangeOffers");

        entity.HasIndex(e => e.IdAuthor, "ExchangeOffer_to_Author_idx");

        entity.HasIndex(e => e.IdBook, "ExchangeOffer_to_Book_FK_idx");

        entity.HasIndex(e => e.IdCategory, "ExchangeOffer_to_Category_idx");

        entity.HasIndex(e => e.IdPosting, "ExchangeOffer_to_Posting_FK_idx");

        entity.HasOne(d => d.IdAuthorNavigation)
            .WithMany(p => p.TBExchangeOffers)
            .HasForeignKey(d => d.IdAuthor)
            .HasConstraintName("ExchangeOffer_to_Author_FK");

        entity.HasOne(d => d.IdBookNavigation)
            .WithMany(p => p.TBExchangeOffers)
            .HasForeignKey(d => d.IdBook)
            .HasConstraintName("ExchangeOffer_to_Book_FK");

        entity.HasOne(d => d.IdCategoryNavigation)
            .WithMany(p => p.TBExchangeOffers)
            .HasForeignKey(d => d.IdCategory)
            .HasConstraintName("ExchangeOffer_to_Category_FK");

        entity.HasOne(d => d.IdPostingNavigation)
            .WithMany(p => p.TBExchangeOffers)
            .HasForeignKey(d => d.IdPosting)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ExchangeOffer_to_Posting_FK");
    }
}
