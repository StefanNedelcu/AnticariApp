using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBCategory
    {
        public TBCategory()
        {
            TBBookCategories = new HashSet<TBBookCategory>();
            TBExchangeOffers = new HashSet<TBExchangeOffer>();
            TBUserCategoryPreferences = new HashSet<TBUserCategoryPreference>();
        }

        public long IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<TBBookCategory> TBBookCategories { get; set; }
        public virtual ICollection<TBExchangeOffer> TBExchangeOffers { get; set; }
        public virtual ICollection<TBUserCategoryPreference> TBUserCategoryPreferences { get; set; }
    }
}
