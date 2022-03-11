using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBUser
    {
        public TBUser()
        {
            Tbpostings = new HashSet<TBPosting>();
            TbuserAddresses = new HashSet<TBUserAddress>();
            TbuserAuthorPreferences = new HashSet<TBUserAuthorPreference>();
            TbuserCategoryPreferences = new HashSet<TBUserCategoryPreference>();
            TbuserStatistics = new HashSet<TBUserStatistic>();
            TbuserWishlistItems = new HashSet<TBUserWishlistItem>();
        }

        public long IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserRole { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<TBPosting> Tbpostings { get; set; }
        public virtual ICollection<TBUserAddress> TbuserAddresses { get; set; }
        public virtual ICollection<TBUserAuthorPreference> TbuserAuthorPreferences { get; set; }
        public virtual ICollection<TBUserCategoryPreference> TbuserCategoryPreferences { get; set; }
        public virtual ICollection<TBUserStatistic> TbuserStatistics { get; set; }
        public virtual ICollection<TBUserWishlistItem> TbuserWishlistItems { get; set; }
    }
}
