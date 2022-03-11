using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBCountry
    {
        public TBCountry()
        {
            Tbcities = new HashSet<TBCity>();
        }

        public long IdCountry { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<TBCity> Tbcities { get; set; }
    }
}
