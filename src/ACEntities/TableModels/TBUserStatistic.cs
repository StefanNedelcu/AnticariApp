using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBUserStatistic
    {
        public long IdUserStatistics { get; set; }
        public long IdUser { get; set; }
        public decimal UserAvgRating { get; set; }
        public int SoldItems { get; set; }
        public int ReadBooks { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual TBUser IdUserNavigation { get; set; }
    }
}
