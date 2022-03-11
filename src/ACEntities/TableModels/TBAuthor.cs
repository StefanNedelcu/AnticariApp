using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBAuthor
    {
        public TBAuthor()
        {
            Tbbooks = new HashSet<TBBook>();
            TbexchangeOffers = new HashSet<TBExchangeOffer>();
            TbuserAuthorPreferences = new HashSet<TBUserAuthorPreference>();
        }

        public long IdAuthor { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }

        public virtual ICollection<TBBook> Tbbooks { get; set; }
        public virtual ICollection<TBExchangeOffer> TbexchangeOffers { get; set; }
        public virtual ICollection<TBUserAuthorPreference> TbuserAuthorPreferences { get; set; }
    }
}
