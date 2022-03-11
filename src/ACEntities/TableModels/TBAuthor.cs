#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBAuthor
    {
        public TBAuthor()
        {
            TBBooks = new HashSet<TBBook>();
            TBExchangeOffers = new HashSet<TBExchangeOffer>();
            TBUserAuthorPreferences = new HashSet<TBUserAuthorPreference>();
        }

        public long IdAuthor { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }

        public virtual ICollection<TBBook> TBBooks { get; set; }
        public virtual ICollection<TBExchangeOffer> TBExchangeOffers { get; set; }
        public virtual ICollection<TBUserAuthorPreference> TBUserAuthorPreferences { get; set; }
    }
}
