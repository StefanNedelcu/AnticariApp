using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBPostingImage
    {
        public long IdPostingImage { get; set; }
        public long IdPosting { get; set; }
        public string ImgSrc { get; set; }

        public virtual TBPosting IdPostingNavigation { get; set; }
    }
}
