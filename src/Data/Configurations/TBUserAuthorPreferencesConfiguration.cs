using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBUserAuthorPreferencesConfiguration : IEntityTypeConfiguration<TBUserAuthorPreference>
{
    public void Configure(EntityTypeBuilder<TBUserAuthorPreference> entity)
    {
        entity.HasKey(e => e.IdAuthorPreference)
                .HasName("PRIMARY");

        entity.ToTable("TBUserAuthorPreferences");

        entity.HasIndex(e => e.IdAuthor, "AuthorPreference_to_Author_FK_idx");

        entity.HasIndex(e => e.IdUser, "AuthorPreference_to_User_FK_idx");

        entity.HasOne(d => d.IdAuthorNavigation)
            .WithMany(p => p.TBUserAuthorPreferences)
            .HasForeignKey(d => d.IdAuthor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("AuthorPreference_to_Author_FK");

        entity.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.TBUserAuthorPreferences)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("AuthorPreference_to_User_FK");
    }
}
