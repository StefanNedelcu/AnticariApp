using AnticariApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnticariApp.Data.Context;

public partial class MySqlContext
{
    public virtual DbSet<TBAuthor> TBAuthors { get; set; }
    public virtual DbSet<TBBook> TBBooks { get; set; }
    public virtual DbSet<TBBookCategory> TBBookCategories { get; set; }
    public virtual DbSet<TBCategory> TBCategories { get; set; }
    public virtual DbSet<TBExchangeOffer> TBExchangeOffers { get; set; }
    public virtual DbSet<TBPosting> TBPostings { get; set; }
    public virtual DbSet<TBPostingImage> TBPostingImages { get; set; }
    public virtual DbSet<TBUser> TBUsers { get; set; }
    public virtual DbSet<TBUserAddress> TBUserAddresses { get; set; }
    public virtual DbSet<TBUserAuthorPreference> TBUserAuthorPreferences { get; set; }
    public virtual DbSet<TBUserCategoryPreference> TBUserCategoryPreferences { get; set; }
    public virtual DbSet<TBUserStatistic> TBUserStatistics { get; set; }
    public virtual DbSet<TBUserWishlistItem> TBUserWishlistItems { get; set; }
}
