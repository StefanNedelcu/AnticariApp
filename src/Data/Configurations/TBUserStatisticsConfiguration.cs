using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnticariApp.Data.Configurations;

public class TBUserStatisticsConfiguration : IEntityTypeConfiguration<TBUserStatistic>
{
    public void Configure(EntityTypeBuilder<TBUserStatistic> entity)
    {
        entity.HasKey(e => e.IdUserStatistics)
                .HasName("PRIMARY");

        entity.ToTable("TBUserStatistics");

        entity.HasIndex(e => e.IdUser, "Statistics_to_User_FK_idx");

        entity.Property(e => e.UserAvgRating).HasColumnType("decimal(2,2)");

        entity.HasOne(d => d.User)
            .WithMany(p => p.TBUserStatistics)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Statistics_to_User_FK");
    }
}
