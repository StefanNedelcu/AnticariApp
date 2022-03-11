using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBCategory
    {
        public TBCategory()
        {
            TbbookCategories = new HashSet<TBBookCategory>();
            TbexchangeOffers = new HashSet<TBExchangeOffer>();
            TbuserCategoryPreferences = new HashSet<TBUserCategoryPreference>();
        }

        public long IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<TBBookCategory> TbbookCategories { get; set; }
        public virtual ICollection<TBExchangeOffer> TbexchangeOffers { get; set; }
        public virtual ICollection<TBUserCategoryPreference> TbuserCategoryPreferences { get; set; }
    }
}
