﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBUserWishlistItem
    {
        public long IdWishlistItem { get; set; }
        public long IdUser { get; set; }
        public long IdBook { get; set; }

        public virtual TBBook IdBookNavigation { get; set; }
        public virtual TBUser IdUserNavigation { get; set; }
    }
}
