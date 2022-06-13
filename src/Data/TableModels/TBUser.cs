#nullable disable

namespace AnticariApp.Data.TableModels;

public partial class TBUser
{
    public TBUser()
    {
        TBPostings = new HashSet<TBPosting>();
        TBUserAddresses = new HashSet<TBUserAddress>();
        TBUserAuthorPreferences = new HashSet<TBUserAuthorPreference>();
        TBUserCategoryPreferences = new HashSet<TBUserCategoryPreference>();
        TBUserStatistics = new HashSet<TBUserStatistic>();
        TBUserWishlistItems = new HashSet<TBUserWishlistItem>();
    }

    public long IdUser { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int UserRole { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<TBPosting> TBPostings { get; set; }
    public virtual ICollection<TBUserAddress> TBUserAddresses { get; set; }
    public virtual ICollection<TBUserAuthorPreference> TBUserAuthorPreferences { get; set; }
    public virtual ICollection<TBUserCategoryPreference> TBUserCategoryPreferences { get; set; }
    public virtual ICollection<TBUserStatistic> TBUserStatistics { get; set; }
    public virtual ICollection<TBUserWishlistItem> TBUserWishlistItems { get; set; }
}
