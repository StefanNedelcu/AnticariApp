using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBBook
    {
        public TBBook()
        {
            TbbookCategories = new HashSet<TBBookCategory>();
            TbexchangeOffers = new HashSet<TBExchangeOffer>();
            Tbpostings = new HashSet<TBPosting>();
            TbuserWishlistItems = new HashSet<TBUserWishlistItem>();
        }

        public long IdBook { get; set; }
        public long IdAuthor { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }

        public virtual TBAuthor IdAuthorNavigation { get; set; }
        public virtual ICollection<TBBookCategory> TbbookCategories { get; set; }
        public virtual ICollection<TBExchangeOffer> TbexchangeOffers { get; set; }
        public virtual ICollection<TBPosting> Tbpostings { get; set; }
        public virtual ICollection<TBUserWishlistItem> TbuserWishlistItems { get; set; }
    }
}
