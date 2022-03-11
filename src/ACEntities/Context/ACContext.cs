using ACEntities.TableModels;
using ACUtils.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

#nullable disable

namespace ACEntities.Context
{
    public partial class ACContext : DbContext
    {
        private readonly ConnectionStrings _connectionSettings;

        public ACContext()
        {
            
        }

        public ACContext(DbContextOptions<ACContext> options, IOptions<ConnectionStrings> connectionStrings)
            : base(options)
        {
            _connectionSettings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_connectionSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBAuthor>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("PRIMARY");

                entity.ToTable("TBAuthors");

                entity.Property(e => e.AuthorDescription).HasMaxLength(1000);

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TBBook>(entity =>
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
                    .WithMany(p => p.Tbbooks)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Book_to_Author_FK");
            });

            modelBuilder.Entity<TBBookCategory>(entity =>
            {
                entity.HasKey(e => e.IdBookCategory)
                    .HasName("PRIMARY");

                entity.ToTable("TBBookCategories");

                entity.HasIndex(e => e.IdBook, "BookCategory_to_Book_FK_idx");

                entity.HasIndex(e => e.IdCategory, "BookCategory_to_Category_FK_idx");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.TbbookCategories)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BookCategory_to_Book_FK");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.TbbookCategories)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BookCategory_to_Category_FK");
            });

            modelBuilder.Entity<TBCategory>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PRIMARY");

                entity.ToTable("TBCategories");

                entity.Property(e => e.CategoryDescription).HasMaxLength(1000);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TBCity>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PRIMARY");

                entity.ToTable("TBCities");

                entity.HasIndex(e => e.IdCountry, "City_to_Country_FK_idx");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Tbcities)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("City_to_Country_FK");
            });

            modelBuilder.Entity<TBCountry>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PRIMARY");

                entity.ToTable("TBCountries");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TBExchangeOffer>(entity =>
            {
                entity.HasKey(e => e.IdExchangeOffer)
                    .HasName("PRIMARY");

                entity.ToTable("TBExchangeOffers");

                entity.HasIndex(e => e.IdAuthor, "ExchangeOffer_to_Author_idx");

                entity.HasIndex(e => e.IdBook, "ExchangeOffer_to_Book_FK_idx");

                entity.HasIndex(e => e.IdCategory, "ExchangeOffer_to_Category_idx");

                entity.HasIndex(e => e.IdPosting, "ExchangeOffer_to_Posting_FK_idx");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.TbexchangeOffers)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("ExchangeOffer_to_Author_FK");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.TbexchangeOffers)
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("ExchangeOffer_to_Book_FK");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.TbexchangeOffers)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("ExchangeOffer_to_Category_FK");

                entity.HasOne(d => d.IdPostingNavigation)
                    .WithMany(p => p.TbexchangeOffers)
                    .HasForeignKey(d => d.IdPosting)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ExchangeOffer_to_Posting_FK");
            });

            modelBuilder.Entity<TBPosting>(entity =>
            {
                entity.HasKey(e => e.IdPosting)
                    .HasName("PRIMARY");

                entity.ToTable("TBPostings");

                entity.HasIndex(e => e.IdBook, "Posting_to_Book_FK_idx");

                entity.HasIndex(e => e.IdOwnerUser, "Posting_to_Owner_FK_idx");

                entity.Property(e => e.PostingDescription).HasMaxLength(1000);

                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Tbpostings)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Posting_to_Book_FK");

                entity.HasOne(d => d.IdOwnerUserNavigation)
                    .WithMany(p => p.Tbpostings)
                    .HasForeignKey(d => d.IdOwnerUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Posting_to_Owner_FK");
            });

            modelBuilder.Entity<TBPostingImage>(entity =>
            {
                entity.HasKey(e => e.IdPostingImage)
                    .HasName("PRIMARY");

                entity.ToTable("TBPostingImages");

                entity.HasIndex(e => e.IdPosting, "PostingImage_to_Posting_FK_idx");

                entity.Property(e => e.ImgSrc)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdPostingNavigation)
                    .WithMany(p => p.TbpostingImages)
                    .HasForeignKey(d => d.IdPosting)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PostingImage_to_Posting_FK");
            });

            modelBuilder.Entity<TBUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("TBUsers");

                entity.HasIndex(e => e.Email, "Email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TBUserAddress>(entity =>
            {
                entity.HasKey(e => e.IdUserAddress)
                    .HasName("PRIMARY");

                entity.ToTable("TBUserAddresses");

                entity.HasIndex(e => e.IdCity, "Address_to_City_FK_idx");

                entity.HasIndex(e => e.IdUser, "Address_to_User_FK_idx");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.TbuserAddresses)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Address_to_City_FK");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbuserAddresses)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Address_to_User_FK");
            });

            modelBuilder.Entity<TBUserAuthorPreference>(entity =>
            {
                entity.HasKey(e => e.IdAuthorPreference)
                    .HasName("PRIMARY");

                entity.ToTable("TBUserAuthorPreferences");

                entity.HasIndex(e => e.IdAuthor, "AuthorPreference_to_Author_FK_idx");

                entity.HasIndex(e => e.IdUser, "AuthorPreference_to_User_FK_idx");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.TbuserAuthorPreferences)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AuthorPreference_to_Author_FK");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbuserAuthorPreferences)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AuthorPreference_to_User_FK");
            });

            modelBuilder.Entity<TBUserCategoryPreference>(entity =>
            {
                entity.HasKey(e => e.IdCategoryPreference)
                    .HasName("PRIMARY");

                entity.ToTable("TBUserCategoryPreferences");

                entity.HasIndex(e => e.IdCategory, "CategoryPreference_to_Category_FK_idx");

                entity.HasIndex(e => e.IdUser, "CategoryPreference_to_User_FK_idx");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.TbuserCategoryPreferences)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryPreference_to_Category_FK");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbuserCategoryPreferences)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryPreference_to_User_FK");
            });

            modelBuilder.Entity<TBUserStatistic>(entity =>
            {
                entity.HasKey(e => e.IdUserStatistics)
                    .HasName("PRIMARY");

                entity.ToTable("TBUserStatistics");

                entity.HasIndex(e => e.IdUser, "Statistics_to_User_FK_idx");

                entity.Property(e => e.UserAvgRating).HasColumnType("decimal(2,2)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbuserStatistics)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Statistics_to_User_FK");
            });

            modelBuilder.Entity<TBUserWishlistItem>(entity =>
            {
                entity.HasKey(e => e.IdWishlistItem)
                    .HasName("PRIMARY");

                entity.ToTable("TBUserWishlistItems");

                entity.HasIndex(e => e.IdBook, "WishlistItem_to_Book_FK_idx");

                entity.HasIndex(e => e.IdUser, "WishlistItem_to_User_FK_idx");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.TbuserWishlistItems)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WishlistItem_to_Book_FK");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbuserWishlistItems)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WishlistItem_to_User_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
