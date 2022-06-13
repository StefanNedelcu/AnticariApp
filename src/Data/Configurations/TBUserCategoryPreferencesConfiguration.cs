using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBUserCategoryPreferencesConfiguration : IEntityTypeConfiguration<TBUserCategoryPreference>
{
    public void Configure(EntityTypeBuilder<TBUserCategoryPreference> entity)
    {
        entity.HasKey(e => e.IdCategoryPreference)
                .HasName("PRIMARY");

        entity.ToTable("TBUserCategoryPreferences");

        entity.HasIndex(e => e.IdCategory, "CategoryPreference_to_Category_FK_idx");

        entity.HasIndex(e => e.IdUser, "CategoryPreference_to_User_FK_idx");

        entity.HasOne(d => d.IdCategoryNavigation)
            .WithMany(p => p.TBUserCategoryPreferences)
            .HasForeignKey(d => d.IdCategory)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("CategoryPreference_to_Category_FK");

        entity.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.TBUserCategoryPreferences)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("CategoryPreference_to_User_FK");
    }
}
