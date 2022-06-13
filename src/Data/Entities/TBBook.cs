#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBBook
{
    public TBBook()
    {
        TBBookCategories = new HashSet<TBBookCategory>();
        TBExchangeOffers = new HashSet<TBExchangeOffer>();
        TBPostings = new HashSet<TBPosting>();
        TBUserWishlistItems = new HashSet<TBUserWishlistItem>();
    }

    public long IdBook { get; set; }
    public long IdAuthor { get; set; }
    public string BookTitle { get; set; }
    public string BookDescription { get; set; }

    public virtual TBAuthor IdAuthorNavigation { get; set; }
    public virtual ICollection<TBBookCategory> TBBookCategories { get; set; }
    public virtual ICollection<TBExchangeOffer> TBExchangeOffers { get; set; }
    public virtual ICollection<TBPosting> TBPostings { get; set; }
    public virtual ICollection<TBUserWishlistItem> TBUserWishlistItems { get; set; }
}
