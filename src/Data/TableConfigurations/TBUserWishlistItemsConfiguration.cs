using AnticariApp.Data.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.TableConfigurations;

public class TBUserWishlistItemsConfiguration : IEntityTypeConfiguration<TBUserWishlistItem>
{
    public void Configure(EntityTypeBuilder<TBUserWishlistItem> entity)
    {
        entity.HasKey(e => e.IdWishlistItem)
                .HasName("PRIMARY");

        entity.ToTable("TBUserWishlistItems");

        entity.HasIndex(e => e.IdBook, "WishlistItem_to_Book_FK_idx");

        entity.HasIndex(e => e.IdUser, "WishlistItem_to_User_FK_idx");

        entity.HasOne(d => d.IdBookNavigation)
            .WithMany(p => p.TBUserWishlistItems)
            .HasForeignKey(d => d.IdBook)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("WishlistItem_to_Book_FK");

        entity.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.TBUserWishlistItems)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("WishlistItem_to_User_FK");
    }
}
